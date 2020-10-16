package com.oraycn.screenmonitor;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.TextView;

import com.oraycn.omcs.DesktopDeviceRunMode;
import com.oraycn.omcs.IConnectionEventListener;
import com.oraycn.omcs.IDeviceGuestListener;
import com.oraycn.omcs.MultimediaDeviceType;
import com.oraycn.omcs.MultimediaManagerFactory;
import com.oraycn.omcs.communicate.common.LogonResponse;

import java.util.ArrayList;
import java.util.List;

public class ProviderActivity extends Activity {

    private TextView tv_state, tv_tips;
    private CheckBox checkbox_shareScreen;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_provider);
        TextView tv_id = (TextView) findViewById(R.id.tv_id);
        tv_id.setText("当前帐号：" + getIntent().getStringExtra("id"));
        tv_state = (TextView) findViewById(R.id.textView_state);
        tv_tips = (TextView) findViewById(R.id.textview_tips);
        MultimediaManagerFactory.GetSingleton().setDesktopRecordActivity(this);
        checkbox_shareScreen = (CheckBox) findViewById(R.id.checkbox_shareScreen);
        checkbox_shareScreen.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                try {
                    if (isChecked) {
                        MultimediaManagerFactory.GetSingleton().setDesktopDeviceRunMode(DesktopDeviceRunMode.RunAlways);
                    } else {
                        MultimediaManagerFactory.GetSingleton().setDesktopDeviceRunMode(DesktopDeviceRunMode.RunWhenNeed);
                    }
                } catch (Exception ex) {
                    ex.printStackTrace();
                }
            }
        });
        MultimediaManagerFactory.GetSingleton().setDeviceGuestListener(new IDeviceGuestListener() {
            @Override
            public void onDeviceConnected(String targetID, MultimediaDeviceType multimediaDeviceType) {
                if (!monitors.contains(targetID) && multimediaDeviceType == MultimediaDeviceType.Desktop) {
                    monitors.add(targetID);
                    showTips();
                }
            }

            @Override
            public void onDeviceDisconnected(String targetID, MultimediaDeviceType multimediaDeviceType) {
                if (monitors.contains(targetID) && multimediaDeviceType == MultimediaDeviceType.Desktop) {
                    monitors.remove(targetID);
                    showTips();
                }
            }
        });

        MultimediaManagerFactory.GetSingleton().setConnectionEventListener(new IConnectionEventListener() {
            @Override
            public void connectionInterrupted() {
                Message message = new Message();
                message.what = 2;
                message.obj = "断开";
                myHandler.sendMessage(message);
            }

            @Override
            public void connectionRebuildStart() {
                Message message = new Message();
                message.what = 2;
                message.obj = "开始重连";
                myHandler.sendMessage(message);
            }

            @Override
            public void relogonCompleted(LogonResponse logonResponse) {
                Message message = new Message();
                message.what = 2;
                message.obj = "正常（重连成功）";
                myHandler.sendMessage(message);
            }
        });
    }

    private List<String> monitors = new ArrayList<String>();

    private void showTips() {
        String str = "";
        for (String id : monitors) {
            str += id + ",";
        }
        if (str.length() > 0) {
            str = str.substring(0, str.length() - 1);
        }
        Message message = new Message();
        message.what = 1;
        message.obj = "以下用户在观看我的屏幕：\r\n" + str;
        myHandler.sendMessage(message);
    }

    //退出
    public void exit(View view) {
        MultimediaManagerFactory.GetSingleton().close();
        finish();
    }

    class mHandler extends Handler {

        // 通过复写handlerMessage() 从而确定更新UI的操作
        @Override
        public void handleMessage(Message msg) {
            switch (msg.what)
            {
                case 1:
                    tv_tips.setText(msg.obj.toString());
                    break;
                case 2:
                    tv_state.setText("连接状态："+msg.obj.toString());
                    break;
            }
        }
    }

    private ProviderActivity.mHandler myHandler = new ProviderActivity.mHandler();

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        MultimediaManagerFactory.GetSingleton().setDesktopRecordActivityResult(requestCode, resultCode, data);
        if (requestCode == 1) {
            if (resultCode != Activity.RESULT_OK) {
                checkbox_shareScreen.setChecked(false);
            }
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
    }
}