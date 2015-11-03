package com.bit.kakkr1.digitalsignage;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Window;
import android.view.WindowManager;
import android.webkit.WebSettings;
import android.webkit.WebView;

public class MainActivity extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        // remove title and full screen
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
        WindowManager.LayoutParams.FLAG_FULLSCREEN);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        //Alert Box on activity start
        AlertDialog alert = new AlertDialog.Builder(MainActivity.this).create();
        alert.setTitle("Project Room");
        alert.setMessage("You are now accessing Project Room Screen.");
        alert.setButton("OK", new DialogInterface.OnClickListener() {

            public void onClick(DialogInterface dialog, int which) {
                // TODO Auto-generated method stub

            }
        });
        alert.show();

        //load a web page in the WebView, use loadUrl()
         WebView myWebView = (WebView) findViewById(R.id.webView);
        //retrieve WebSettings with getSettings()
         WebSettings webSettings = myWebView.getSettings();
        //enable JavaScript with setJavaScriptEnabled().
         webSettings.setJavaScriptEnabled(true);
        // myWebView.loadUrl("http://192.168.1.107");
          myWebView.loadUrl("http://10.35.122.158 ");
      // myWebView.loadUrl("http://google.com");


    }


   }
