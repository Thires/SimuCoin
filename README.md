![image](https://user-images.githubusercontent.com/28072996/229660411-6a5595b1-bd0b-4a08-9da1-63aec016c0a6.png)

# SimuCoin
Plugin for Genie frontend to log into simucoin to get current amount, time left or to claim

Commands:<br>
/sc or /simucoin will open the GUI.<br>
/sc username password or /simucoin username password will automatically login using the GUI.<br>
/scnf or /sct username password will login without the GUI, echoing to game window.

Can save multiple usernames/passwords, they will be stored in SimuCoin.xml.
The passwords are encrypted with a randomly generated key cipher each time it is saved.

When window is open, can hit esc key to close it or use window close button.

If simucoins are available to be claimed, they will be claimed when you login with the plugin.

This can be set so that when you login the GUI will pop open for you to claim #trigger {^Welcome to DragonRealms} {#put /sc}
