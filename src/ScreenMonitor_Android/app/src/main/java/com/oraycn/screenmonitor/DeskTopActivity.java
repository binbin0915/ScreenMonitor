package com.oraycn.screenmonitor;

import android.app.Activity;
import android.content.Context;
import android.content.pm.ActivityInfo;
import android.content.res.Configuration;
import android.graphics.BitmapFactory;
import android.media.AudioManager;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.View;
import android.view.WindowManager;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RelativeLayout;

import com.oraycn.omcs.ConnectResult;
import com.oraycn.omcs.ConnectorDisconnectedType;
import com.oraycn.omcs.IConnectorEventListener;
import com.oraycn.omcs.MachineType;
import com.oraycn.omcs.core.DesktopConnector;
import com.oraycn.omcs.core.DesktopSurfaceView;
import com.oraycn.omcs.core.MicrophoneConnector;
import com.oraycn.screenmonitor.utils.ToastUtils;


public class DeskTopActivity extends Activity {
    private static final int REQUEST_CODE = 1000;
    DesktopSurfaceView otherView = null;
    ImageView hang_up,resetSize_btn;
    String targetUid = "";
    DesktopConnector desktopConnector;
    MicrophoneConnector microphoneConnector;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_desk_top);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        Bundle bundle = getIntent().getExtras();
        targetUid = bundle.getString("targetUid");
        //显示对方数据view
        otherView = (DesktopSurfaceView) findViewById(R.id.Desk_surface_remote);
        otherView.setPointer(BitmapFactory.decodeResource(getResources(),R.drawable.cursor));//设置鼠标指针图片
        hang_up = (ImageView) findViewById(R.id.desk_hung_up);

        //挂断
        hang_up.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                finish();
            }
        });
        resetSize_btn=(ImageView) (findViewById(R.id.resetSizeBtn));
        resetSize_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                otherView.resetScale();
            }
        });
        otherView.setGuestureEnabled(true);//设置为观看者模式 （可操作屏幕显示 放大缩小）

        desktopConnector = new DesktopConnector();
        startDesktopConnect();


        Boolean audioEnabled=bundle.getBoolean("audioEnabled");
        if(audioEnabled)
        {
            this.openSpeaker(DeskTopActivity.this);
            microphoneConnector=new MicrophoneConnector();
            microphoneConnector.setConnectorEventListener(new IConnectorEventListener() {
                @Override
                public void connectEnded(ConnectResult connectResult) {
                    if( connectResult!= ConnectResult.Succeed){
                        Message msg = Message.obtain(); // 实例化消息对象
                        msg.what = 3; // 消息标识
                        msg.obj = "麦克风连接失败：" + connectResult.toString(); // 消息内容存放
                        myHandler.sendMessage(msg);
                    }
                }

                @Override
                public void disconnected(ConnectorDisconnectedType connectorDisconnectedType) {
                    if(connectorDisconnectedType==ConnectorDisconnectedType.OwnerActiveDisconnect||connectorDisconnectedType==ConnectorDisconnectedType.GuestActiveDisconnect)
                    {
                        return;
                    }
                    Message msg = Message.obtain(); // 实例化消息对象
                    msg.what = 3; // 消息标识
                    msg.obj = "麦克风连接断开：" + connectorDisconnectedType.toString(); // 消息内容存放
                    myHandler.sendMessage(msg);
                }
            });
            microphoneConnector.beginConnect(targetUid);
        }

    }
    @Override
    protected void onResume() {
        //设置为可以横竖平自由切换
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_SENSOR);
        super.onResume();
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
        int orientation = newConfig.orientation;
        RelativeLayout.LayoutParams params=null;
        if (orientation == Configuration.ORIENTATION_PORTRAIT) {
            // 竖屏操作
            if(desktopConnector.getOwnerMachineType()== MachineType.DotNET){
                int width= otherView.getHeight();
                int newHeight= width*9/16;
                params=new RelativeLayout.LayoutParams(width,newHeight);
            }else {
                params =new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MATCH_PARENT,RelativeLayout.LayoutParams.MATCH_PARENT);
            }
        }
        else if (orientation == Configuration.ORIENTATION_LANDSCAPE) {
            //  横屏操作
            if(desktopConnector.getOwnerMachineType()== MachineType.DotNET)
            {
                params =new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MATCH_PARENT,RelativeLayout.LayoutParams.MATCH_PARENT);
            }else {
                int height= otherView.getWidth();
                int newWidth= height*9/16;
                params=new RelativeLayout.LayoutParams(newWidth,height);
            }
        }
        otherView.setLayoutParams(params);
    }

    class mHandler extends Handler {

        // 通过复写handlerMessage() 从而确定更新UI的操作
        @Override
        public void handleMessage(Message msg) {
            ToastUtils.showLong(DeskTopActivity.this.getApplication(),msg.obj.toString());
        }
    }
    private mHandler myHandler=new mHandler();

    private void startDesktopConnect() {
        desktopConnector.setOtherVideoPlayerSurfaceView(otherView);//绑定用于显示对方桌面的DesktopSurfaceView
        desktopConnector.setConnectorEventListener(new IConnectorEventListener() {
            @Override
            public void connectEnded(ConnectResult connectResult) {
                if( connectResult!= ConnectResult.Succeed){
                    Message msg = Message.obtain(); // 实例化消息对象
                    msg.what = 1; // 消息标识
                    msg.obj = "远程桌面连接失败：" + connectResult.toString(); // 消息内容存放
                    myHandler.sendMessage(msg);
                }
            }
            @Override
            public void disconnected(ConnectorDisconnectedType connectorDisconnectedType) {
                if(connectorDisconnectedType==ConnectorDisconnectedType.OwnerActiveDisconnect||connectorDisconnectedType==ConnectorDisconnectedType.GuestActiveDisconnect)
                {
                    return;
                }
                Message msg = Message.obtain(); // 实例化消息对象
                msg.what = 2; // 消息标识
                msg.obj = "远程桌面连接断开：" + connectorDisconnectedType.toString();// 消息内容存放
                myHandler.sendMessage(msg);
            }
        });

        desktopConnector.beginConnect(targetUid);
    }


    @Override
    protected void onDestroy() {
        super.onDestroy();
        if(desktopConnector.isConnected())
        {
            desktopConnector.disconnect();
        }
        if(microphoneConnector!=null)
        {
            microphoneConnector.disconnect();
        }
    }

    //打开扬声器
    private  int openSpeaker(Context mContext) {
        int currVolume = 0;
        try {
            AudioManager audioManager = (AudioManager) mContext.getSystemService(Context.AUDIO_SERVICE);
            //audioManager.setMode(AudioManager.ROUTE_SPEAKER);
            audioManager.setMode(AudioManager.MODE_IN_CALL);
            currVolume = audioManager.getStreamVolume(AudioManager.STREAM_VOICE_CALL);

            if (!audioManager.isSpeakerphoneOn()) {
                audioManager.setSpeakerphoneOn(true);
                int maxVolume = audioManager.getStreamMaxVolume(AudioManager.STREAM_VOICE_CALL);
                audioManager.setStreamVolume(AudioManager.STREAM_VOICE_CALL, maxVolume,AudioManager.STREAM_VOICE_CALL);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return currVolume;
    }

}
