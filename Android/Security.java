package com.commernet.codeenforcement.Helper;

import java.io.UnsupportedEncodingException;
import java.util.Locale;

import javax.crypto.Cipher;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.DESKeySpec;
import javax.crypto.spec.SecretKeySpec;

import android.content.Context;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.telephony.TelephonyManager;
import android.util.Base64;
import android.util.DisplayMetrics;

/**
 * ³£ÓÃ¹¤¾ßÀà
 * 
 * @author talver
 */
public class Security {
	final static String AES_KEY = "Q*1_3@c!4kd^j&g%";

	/**
	 * ×Ö·û´®¶Ô³Æ¼ÓÃÜ
	 * 
	 * @param str
	 *            ´ý¼ÓÃÜ×Ö·û´®
	 * @return ¼ÓÃÜºó×Ö·û´®
	 */
	public static String aesEncrypt(String str) {
		try {
			String password = AES_KEY;
			SecretKeySpec skeySpec = new SecretKeySpec(password.getBytes(), "AES");
			Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
			cipher.init(Cipher.ENCRYPT_MODE, skeySpec);
			String strTmp = Base64.encodeToString(cipher.doFinal(str.getBytes()), Base64.DEFAULT);
			return strTmp;
		} catch (Exception e) {
			e.printStackTrace();
		}
		return str;
	}

	/**
	 * ×Ö·û´®¶Ô³Æ½âÃÜ
	 * 
	 * @param str
	 *            ´ý½âÃÜ×Ö·û´®
	 * @return ½âÃÜºó×Ö·û´®
	 */
	public static String aesDecrypt(String str) {
		try {
			String password = AES_KEY;
			SecretKeySpec skeySpec = new SecretKeySpec(password.getBytes(), "AES");
			Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
			cipher.init(Cipher.DECRYPT_MODE, skeySpec);
			String strTmp = new String(cipher.doFinal(Base64.decode(str, Base64.DEFAULT)));
			return strTmp;
		} catch (Exception ex) {
			ex.printStackTrace();
		}
		return str;
	}
}
