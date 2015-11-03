package com.bit.kakkr1.digitalsignage;

import android.bluetooth.BluetoothAdapter;

import android.content.Intent;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;

import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.TextView;



public class BTUser extends ActionBarActivity {
    TextView txtView;
    private Button mactivateBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        // remove title and full screen
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
        WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_btuser);
        mactivateBtn = (Button) findViewById(R.id.button3);
        final BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        txtView = (TextView) findViewById(R.id.textView3);
        txtView.setText("Device Address: " + mBluetoothAdapter.getAddress().toUpperCase().toString());

        //activate bluetooth and make it discoverable
        mactivateBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (mBluetoothAdapter.isEnabled()) {
                    mBluetoothAdapter.disable();

                    showDisabled();
                } else {
                    showEnabled();

                    Intent intent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
                    startActivityForResult(intent, 1000);
                    Intent discoverableIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE);
                    discoverableIntent.putExtra(BluetoothAdapter.EXTRA_DISCOVERABLE_DURATION, 120);
                    startActivity(discoverableIntent);
                }
            }



        });

        if (mBluetoothAdapter.isEnabled()) {
            showEnabled();
        } else {
            showDisabled();
        }

    }
    //methods to change button properties
    private void showEnabled() {

        mactivateBtn.setText("Disable");
        mactivateBtn.setEnabled(true);

    }
    private void showDisabled() {

        mactivateBtn.setText("Enable");
        mactivateBtn.setEnabled(true);

    }

}
