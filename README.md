# MvvmDemo2_Channels
MVVM Demo 2 - "Channels" - In-Memory CRUD Application

This is a (very!) simple Xamarin Forms application that uses the MVVM architectural design pattern. Its intent is to serve as a demo of how MVVM can look in a Xamarin app.

NOTE: This is the Shared (cross-app) Xamarin sub-folder in the Xamarin Forms solution. It does not include or require the sub-folders for Android/"Droid", iOS, or Windows/UWP. 

The app is a "CRUD" (create, read, update, delete) type program that allows the user to create, update, and delete a list of television channels - their callsign, their city of license, their channel number, and the number of cable systems on which the signal is carried. 

The upper part of the app's main page is a ListView which uses as its ItemsSource an ObservableCollection of Channel objects.

The bottom part of the app's main page has entry fields for a new channel, as well as the following buttons:

- Add. Adds whatever has been entered in the entry fields.

- Delete. After tapping/clicking on a row in the upper part of the screen, tap this button to remove the row.

- Reset. Clears the entry text fields.

- Print To Log. Useful in Visual Studio only. Shows diagnostic messages produced using Debug.WriteLine instructions.

- MessageBox. Displays a DisplayEntry dialogbox.

- About. Displays a second, separate "About" page.



DISCLAIMERS

- This is intentionally a simple app, and has no user input error checking, no exception trapping, or any of the other nice things that make a production app. 

- This is not a 100% "pure" MVVM implementation, but it's close enough that newbies to MVVM architecture will (hopefully) get the general idea of what MVVM can do.

- This app does NOT store or persist data. For that, some kind of FileHelper method - defined using the DependencyService interface to runa platform-specific method - would be required, along with references to SQLite (assuming any entered data are to be store locally). For data being stored online by way of a web service, such a FileHelper method might not be necessary. 

