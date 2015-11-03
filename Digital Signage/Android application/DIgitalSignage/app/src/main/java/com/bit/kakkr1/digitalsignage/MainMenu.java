package com.bit.kakkr1.digitalsignage;


import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;


public class MainMenu extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        // remove title and full screen
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
        WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_menu);

        //launches different activity
        final Button button_user = (Button) findViewById(R.id.button2);
        button_user.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {

                // Perform action on click
                Intent btuser = new Intent("android.intent.action.BTUser");
                startActivity(btuser);

            }

        });
        //launches different activity
        final Button button = (Button) findViewById(R.id.button);
        button.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {

                    Intent screenIntent = new Intent("android.intent.action.Screen");
                    startActivity(screenIntent);
            }
        });
        //launches different activity
        final Button button_register = (Button) findViewById(R.id.button5);
        button_register.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {

                Intent registerIntent = new Intent("android.intent.action.Register");
                startActivity(registerIntent);
            }
        });
    }

}
 