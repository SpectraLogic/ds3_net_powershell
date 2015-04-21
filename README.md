This page documents how to install and use the PowerShell DS3 module.

# Upgrade PowerShell

To run the PowerShell DS3 SDK you'll need to have PowerShell version 3.0 or above.

First check what version of PowerShell is currently installed.

1. Press the Windows key on the keyboard between ctrl and alt.
2. Type "PowerShell" in the search box.
3. Click "Windows PowerShell" with the blue icon. A blue window should appear.
4. Type the following into the prompt and press enter:
       $PSVersionTable.PSVersion.Major
5. If a number of 3 or greater appears when you press enter, then you can skip the rest of this section.
	
Before we download the installer we need to check whether you're running 64-bit Windows.

1. Press the Windows key on the keyboard between ctrl and alt.
2. Type "version" in the search box.
3. Click "Show which operating system your computer is running."
4. Under "System type" check to see whether it says 64-bit.
	
Download and install the latest version of PowerShell.

1. Open the following link in your web browser:
       http://www.microsoft.com/en-us/download/details.aspx?id=40855
2. Click the big "Download" button.
3. If you're running a 64-bit version of Windows, click the checkbox next to "Windows6.1-KB2819745-**x64**-MultiPkg.msu". Otherwise, click the checkbox next to "Windows6.1-KB2819745-**x86**-MultiPkg.msu". (Windows6.1 refers to Microsoft's internal version number. This actually means Windows 7.)
4. Click the "Next" button in the lower right corner of the web page. Your browser should start downloading the installer.
5. Different browsers have different default download locations. Locate the installer in Windows explorer and double-click it.
6. Click next, ok, finish, etc. until the installer completes.
	
# Install the DS3 PowerShell Module

Now install the DS3 module into PowerShell.

1. Download the latest Ds3ClientInstaller.exe from the [Releases](../releases) page.
2. Double-click the installer to run it. The installer has no options or dialogs; it runs silently and completes silently.

# Use the DS3 PowerShell Module

Start a PowerShell session and start using the DS3 commands.

1. Press the Windows key on the keyboard between ctrl and alt.
2. Type "PowerShell" in the search box.
3. Click "Windows PowerShell" with the blue icon. A blue window should appear.
4. Import DS3 into the current session. Type the following and press enter:
       Import-Module Ds3Client
5. Get additional help. Type the following and press enter:
       help Ds3Client
	
