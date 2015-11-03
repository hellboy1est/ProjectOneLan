package com.bit.kakkr1.digitalsignage;

import android.bluetooth.BluetoothAdapter;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.apache.http.HttpEntity;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;

import org.apache.http.client.HttpClient;

import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;

import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;


import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;


public class Register extends AppCompatActivity {

    EditText fName,lName;
    Button btnSubmit;
    public static String url = "http://kate.ict.op.ac.nz/~kakkr1/connect.php";
    String firstname, lastname;
    InputStream is = null;
    String exceptionMessage = "There seems to be some problem connecting to database. " +
            "Please check your Internet Connection and try again.";
    String successMessage = "Data has been entered successfully";

    String bluetooth;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        // remove title
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        super.onCreate(savedInstanceState);

        //Strict mode policy
        StrictMode.ThreadPolicy policy=new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        setContentView(R.layout.activity_register);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        //bluetooth address
        final BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

        fName=(EditText)findViewById(R.id.editfname);
        lName=(EditText)findViewById(R.id.editlname);
        btnSubmit=(Button)findViewById(R.id.btnSubmit);


        btnSubmit.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
            //Storing the values inside edit text inside the string variable
                firstname=""+fName.getText().toString();
                lastname=""+lName.getText().toString();
                bluetooth=mBluetoothAdapter.getAddress().toUpperCase().toString();
                if(firstname.equals("") ||
                        lastname.equals("")){
                    String msg = "One or more fields are empty";
                    fName.setText("");
                    lName.setText("");
                    Toast.makeText(getApplicationContext(), msg, Toast.LENGTH_SHORT).show();
                }
                else{

                    List<NameValuePair> nameValuePairList = new ArrayList<NameValuePair>();
                    nameValuePairList.add(new BasicNameValuePair("name", firstname));
                    nameValuePairList.add(new BasicNameValuePair("lname", lastname));
                    nameValuePairList.add(new BasicNameValuePair("bluetooth", bluetooth));

                    try{

                        HttpClient httpClient = new DefaultHttpClient();
                        HttpPost httpPost = new HttpPost(url);
                        httpPost.setEntity(new UrlEncodedFormEntity(nameValuePairList));
                        HttpResponse httpResponse = httpClient.execute(httpPost);
                        HttpEntity httpEntity = httpResponse.getEntity();
                        is = httpEntity.getContent();
                        fName.setText("");
                        lName.setText("");

                        Toast.makeText(getApplicationContext(), successMessage, Toast.LENGTH_SHORT).show();
                        is.close();
                    }catch(IOException e){
                        Toast.makeText(getApplicationContext(), exceptionMessage, Toast.LENGTH_SHORT).show();
                    }
                }
            }
        });

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }
    private void showEnabled() {


        fName.setText("Disable");
        lName.setEnabled(true);

    }
}
