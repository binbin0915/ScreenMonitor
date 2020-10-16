package com.oraycn.screenmonitor;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;

import com.oraycn.omcs.MultimediaManagerFactory;
import com.oraycn.screenmonitor.utils.ToastUtils;

/**
 * 监控端
 * */
public class MonitorActivity extends AppCompatActivity {

    private EditText et_targetID;
    private CheckBox checkBox_audio;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_monitor);
        TextView tv_id=(TextView)findViewById(R.id.tv_id);
        tv_id.setText("当前帐号："+  getIntent().getStringExtra("id"));
        et_targetID=(EditText)findViewById(R.id.editText_targetID);
        et_targetID.setText("aa01");
        checkBox_audio=(CheckBox)findViewById(R.id.checkbox_audio);
    }

    public void watch_desktop(View view) {
        String targetID=et_targetID.getText().toString();
        if(TextUtils.isEmpty(targetID)){
            ToastUtils.showLong(this,"连接目标不能为空！");
            return;
        }
        Intent intent = new Intent(MonitorActivity.this, DeskTopActivity.class);
        intent.putExtra("targetUid", targetID);
        intent.putExtra("audioEnabled",checkBox_audio.isChecked());
        MonitorActivity.this.startActivity(intent);
    }

    public void exit(View view) {
        MultimediaManagerFactory.GetSingleton().close();
        finish();
    }
}