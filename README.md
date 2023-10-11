![image](https://user-images.githubusercontent.com/28072996/230968213-94371d57-4573-4d6f-b7f5-7171d18985a4.png)

**Requires Genie version 4.0.2.5 or higher to run**<br>
**Uses .Net 6.0**
# SimuCoins version 2.1.1
Plugin for Genie frontend to log into simucoins to get current amount, time left or to claim

Commands:<br>
/sc or /simucoins will open the GUI.<br>
/sc username password or /simucoins username password will automatically login using the GUI.<br>
/sct or /sctext username password will login without the GUI, echoing to game window.<br>
/sca or /scall logs into all accounts saved within the xml, echos to game window

All commands with help after will display info echoed to game window, /sc help and such.

Can save multiple usernames/passwords, they will be stored in SimuCoins.xml.<br>
The passwords are randomly encrypted each time it is saved.

When window is open, can hit esc key to close it or use window close button.

The clear button will clear the fields currently on the GUI, remove button will remove the currently selected account from the xml.

If simucoins are available to be claimed, they will be claimed when you login with the plugin.

This #trigger {^Welcome to DragonRealms \\(\w+\\) v\d+\\.\d+$} {#put /sca} or {#put /scall} can be used so when logging in it will check any saved accounts in the xml.

Thank you testers that made this happen. Annandale, Dantia, and Elec.
