# FitDeck_CSCI4805

  This project within this respository, although unfinished, contains an application that takes in a user's health information 
and allows them to create a profile with the entered information which stores in a database for the user to later have access to 
in order to log back in with on a later date on any device. They will be able to create their own workouts by looking up 
exercises in a third-party database and saving the workout under a specific name and day of the week. They will also have the 
ability to choose from a number of predetermined workouts to add to their list of workouts under a specific day of their choice. 
The workouts in question will also have the ability to be deleted or edited once added. Other functionality include adding rest 
days, starting a workout (which will start a timer and once stopped will record their time), and viewing calories burned and time 
spent that day and weekly. 
  This repository is accidentally split into two branches: the main branch and the master branch. The main branch was created at 
the creation of the repository and the master branch was create at the first commit/push. When first pushed, my terminal would not 
recognize the main branch as a branch and wanted me to push to the master branch. Since then, mine always went to the master and 
my terminal could not find the main branch and I assume Shane's always defaulted to pushing to the main branch; this means that 
all of my code, which is very unorganized, is located in the master and the main branch contains just Shane's code and the 
documentation folder for the code. The only code in folders are his which are separated by Account, WebApi, PreDetermined, and 
UserCreated while al of the rest of the code is just in the main pushed folder as just a bunch of classes with no separation. 

 The instructions for building the project are as follows:
  In order to build this system one would need to install any software IDE that allows for mobile development, such as the one  
used build this system, Microsoft Visual Studio 2019 ustilizing the Xamarin forms cross-platform development tools. Before 
attempting to build, the developer(s) would need to download a few NuGet packages to the project for the UI prior to building to 
reduce error while using them and gain access to Microsoft Azure; they need to add the NewtonsoftJson package, the 
Microsoft.AspNet. WebApi.Client package, the Syncfusion.Xamarin.SfChart package, and if it is not added already, they would need 
to include the Xamarin.Essentials package and the Xamarin.Forms package. Next, it would be most beneficial to build all of the 
class files first in order to get the funtionality base right. Then comes adding the GUI files for each of the pages needed in the 
app and adding their events and their interaction with each of the classes, minus the functionality that calls the APIs which is 
the next step. As just stated, at this point, the APIs should be implemented; this entails instantiating the client/base address 
for the API calls, creating the classes responsible for translating storing the data given by the json file from the API call, and 
the actual calls/authentication methods that ask the API for information and subsequently stores it.The API methods are now added 
to the GUI where necessary for the API to call them at the appropriate times to get the appropriate information. Next, the 
database is added to the project and where it is necessary to make calls to store the information, for example, on pages that add 
workouts to the user profile or when creating the profile itself. The final step would be to test and fix the code and make 
changes where it would prove necessary. 
