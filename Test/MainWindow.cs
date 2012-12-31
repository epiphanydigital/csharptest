using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	public string GetMessageText (int score, double amt) {
		score--;
		string tip = String.Format("{0:C}", Convert.ToDecimal(amt));
		string[] messages = new string[10];
		messages[0] = "You should tip " + tip + ". You a cheap ass bitch.";
		messages[1] = "Wow, your server sucks... or is really ugly. Sorry man. Tip " + tip + ".";
		messages[2] = "Huh... maybe you should have gone to Taco Bell for a healthier alternative. Magic 8 ball says tip " + tip + ".";
		messages[3] = "Great service, but no smile. My drinks were always filled to the brim, but my need for social interaction with those who server me was lacking... I guess " + tip + " will do";
		messages[4] = "I have to go home and wash my hair.  Here's your lousy " + tip;
		messages[5] = "This place is completely average.  I'm ambivalent and therefore leave " + tip + " as my ambivalent tip";
		messages[6] = "I haven't had service this good in weeks! Maybe even days! " + tip;
		messages[7] = "OMG RAWR I NOMMED THE FUCK OUT OF THAT!!! ...and the wait staff ain't bad to look at either. " + tip;
		messages[8] = "I am literally food coma wtf. Just take my money. " + tip;
		messages[9] = "WOW! OH MY GAWD WOW!  I JUST ABOUT CRAPPED MY PANTS THAT SERVICE AND FOOD WAS SO FREAKIN AWESOME!!! Tip===" + tip;
		return messages[score];
	}
	public double GetPercentage(int score) {
		double percentage = score * 0.025;
		return percentage;
	}
	
	protected void OnButton1Clicked (object sender, System.EventArgs e)
	{
		double entry = Convert.ToDouble(entry1.Text);
		int score = Convert.ToInt32(hscale1.Value);
		double percentage = GetPercentage(score);
		textview1.LabelProp = GetMessageText(score,entry * percentage);
	}
}
