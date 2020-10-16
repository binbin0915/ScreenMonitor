package com.oraycn.screenmonitor;

import androidx.annotation.NonNull;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.app.Activity;
import android.app.Application;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioGroup;

import com.oraycn.omcs.MultimediaManagerFactory;
import com.oraycn.omcs.communicate.common.LogonResponse;
import com.oraycn.omcs.communicate.common.LogonResult;
import com.oraycn.screenmonitor.utils.ToastUtils;

public class LoginActivity extends Activity {

    private EditText et_ip,et_id,et_psw;
    private RadioGroup radioGroup;
    private static String[] PERMISSIONS_STORAGE = {
            Manifest.permission.RECORD_AUDIO,
    };
    private static int REQUEST_PERMISSION_CODE = 1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        et_ip=(EditText)findViewById(R.id.et_ip);
        et_id=(EditText)findViewById(R.id.et_id);
        et_psw=(EditText)findViewById(R.id.et_password);
        et_ip.setText(R.string.DefaultIP);
        et_id.setText("aa02");
        et_psw.setText("123456");
        radioGroup=(RadioGroup)findViewById(R.id.radioGroup);
        this.checkPermission();
        this.register();
    }

    private void  register()
    {
        IntentFilter intentFilter = new IntentFilter();
        intentFilter.addAction("android.intent.action.CONFIGURATION_CHANGED");
        registerReceiver(new OrientationReciver(),intentFilter);
    }

    private class OrientationReciver extends BroadcastReceiver
    {
        @Override
        public void onReceive(Context context, Intent intent) {
            Log.i("LoginActivity", "onReceive: "+LoginActivity.this.getWindowManager().getDefaultDisplay().getRotation()*90);// 最后结果 0 ,180竖屏； 90,270 横屏
        }
    }

    public void login(View view)
    {
        String id = et_id.getText().toString();
        String password = et_psw.getText().toString();
        String ipaddStr = et_ip.getText().toString();
        try {
            MultimediaManagerFactory.GetSingleton().setDesktopEncodeQuality(10);//清晰度 值越小越清晰
            MultimediaManagerFactory.GetSingleton().setDesktopMaxFPS(16); //帧频
            MultimediaManagerFactory.GetSingleton().setDesktopZoomCoef(0.5f);//放大率 取值（0.1-1）
            LogonResponse omcsResp = MultimediaManagerFactory.GetSingleton().initialize(id, password, ipaddStr, 9900, getApplication());//登录OMCS服务器
            if (omcsResp.getLogonResult() == LogonResult.Succeed) {
                Intent intent = null;
                boolean isMonitor= radioGroup.getCheckedRadioButtonId()==R.id.radioBtn_monitor;
                if(isMonitor)
                {
                    intent =   new Intent(LoginActivity.this, MonitorActivity.class);
                }else {
                    intent =   new Intent(LoginActivity.this, ProviderActivity.class);
                }
                intent.putExtra("id",id);
                LoginActivity.this.startActivity(intent);
            }else{
                ToastUtils.showLong(LoginActivity.this,omcsResp.getFailureCause());
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }


    private void checkPermission()
    {
        if (Build.VERSION.SDK_INT > Build.VERSION_CODES.LOLLIPOP) {
            if (ActivityCompat.checkSelfPermission(this, Manifest.permission.RECORD_AUDIO) != PackageManager.PERMISSION_GRANTED) {
                ActivityCompat.requestPermissions(this, PERMISSIONS_STORAGE, REQUEST_PERMISSION_CODE);
            }
        }
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        if (requestCode == REQUEST_PERMISSION_CODE) {
            for (int i = 0; i < permissions.length; i++) {
                Log.i("MainActivity", "申请的权限为：" + permissions[i] + ",申请结果：" +
                        grantResults[i]);
            }
        }
    }


}

