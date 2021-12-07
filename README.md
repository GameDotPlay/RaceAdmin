# RaceAdmin
A tool for tracking iRacing incidents and recommending/throwing full course cautions.

## Quick Hints
* You must be a session admin in order for this tool to function as intended since incidents for all
cars are only reported at the end of a race to non-admins.

## Overview

![race admin screenshot](/images/race-admin-highlighted.png)

### 1. Main menu strip
This area allows access to the export table functionality, the settings page, and turning on/off various components of the UI.

### 2. Session/Caution Indicator Panel
This panel displays the name of the current session and will flash yellow when the caution conditions
have been met. Once the caution flag has been thrown in will remain solid yellow until the race resumes
under green flag conditions.
This panel also contains the total incident count and number of incidents since last caution count. See below.

### 3. Total Incident Count
The total incidents count tracks the total number of incidents reported during the current session.
This will get reset to 0 when iRacing moves to the next "session". From practice to qualifying, for example.

### 4. Since Last Caution Count.
The number of incidents since last caution tracks the number of incidents reported since the last full course caution.
This number will be reset to 0 in the case of a full course caution being thrown and then returned back to green flag racing.

### 5. Filter Incidents Based on Last X Minutes
This drop down allows to to only see incidents that have occurred over the past X minutes of this session. Set to Forever for no filtering.

### 6. Time Frame Filtering
These drop downs allow you to only see incidents that occurred between a set period of time in the session.
The time periods are shown in session time. HH:MM
Set the first drop down to the beginning of the time period. Set the second drop down as the end of the time period.
Ex: 2:00 - 7:00 will only show incidents that occurreded between 2:00 and 7:00 of session time (the second column) of the incidents table.

### 7. Visible Rows	
This text informs you of how many rows of the incident table are currently visible due to current filtering settings out of the total number of rows in the table.

### 8. Visible Incidents
This text informs you of how many incident points are currently visible in the incident table due to current filtering settings out of the total number of incident points.

### 9. Incident Table
Displays incidents incurred by drivers as one row per incident.
* Local Time - The local time of day on your computer that the incident occurred.
* Session Time - The time the incident occurred referenced from the beginning of the current session.
* Car Class - (Multiclass only) The class of car that the driver is participating in.
* Car # - The number of the car incurring the incident.
* Team - (Team racing only) The name of the team incurring the incident.
* Driver Name - The name of the driver incurring the incident.
* Incident - The value of the new incident incurred: 1x, 2x, 4x generally. (see below)
* Total - The total number of incidents incurred by the car/driver. (see below)
* Lap # - The lap the car was on when the incident occurred.

Note that due to the way incidents are reported by iRacing, incidents promoted from a 1x to
a 2x or 4x may be reported as two separate 1x incidents or a 1x and a 3x. This may be addressed
in a future update.

During team racing, the Total column will display the team's total incidents followed by the 
driver's total incidents in the same fashion as iRacing does. For example if the team had a total
of 4 incidents and the driver had contributed two incidents at the time of the incident, this 
column would contain "4,2".

## File Menu

### Export
Allows the current view (with filtering applied) of the incidents table to be exported to a CSV file.

### Exit
Closes the application.

## Settings

![race admin screenshot](/images/race-admin-settings.png)

### General
General configuration options for the application.

* Hide incidents during race: When enabled, will hide the incidents table and all incident counts on the main page during a "Race" session.
* Highlight 4x incidents: When enabled, 4x incident rows in the table will be highlighted with the color selected by the user.
* Highlight incident that triggered caution: When enabled: if app is configured to throw caution based on incident count, then the incident that caused the incident threshold to be reached will be highlighted with the color selected by the user.
* Highlight driver if individual incident threshold reached: When enabled, allows the user to set an incident threshold that applies to all drivers individually. Any driver that exceeds that number will have their incidents highlighted with the color selected by the user.

### Full Course Cautions
Options for controlling how the app determines when a full course caution should be thrown and how it reacts in this case.

* Detect tow for caution - (BETA) When enabled, the app will recommend a full course caution when a car has stopped and towed to pit road. This triggers if a car is not currently between the pit cones and not on a pit access road immediately before or after the pit lane.
* Use total incidents to trigger caution - When enabled, a full course caution will be recommended if the total number of incidents since last caution exceeds the number given by the user in the setting below.
* Throw caution flag automatically - (BETA) Attempts to throw a full course caution by sending keypresses to iRacing using the Windows SendKeys functionality when full course caution conditions are met.
* Audio notification - Play an alert sound when full course caution conditions are met.
* Incidents required for caution - The number of incident points required for the app to recommend/throw a full course caution.
* No cautions during last laps - Don't recommend or throw cautions during the last number of laps specified; set to zero to allow cautions up until the checkered flag.
* No cautions during last minutes - Don't recommend or throw cautions during the last number of minutes specified; set to zero to allow cautions up until the checkered flag.

The app can only honor the last laps and last minutes settings when iRacing is reporting laps remaining and/or time remaining via telemetry. If a race is configured as a race to a set number of laps, then the time remaining is not reported by iRacing unless iRacing detects that the session time will expire before the race completes. Similarly when a race is configured as a timed race only, iRacing does not report the number of laps remaining.

## Developer Notes
First, only telemetry fields currently used in this codebase are recorded. While this is mainly to keep the output file size to a minimum, it is also a consequence of the libraries used to read the iRacing telemetry updates. The exact fields captured are those exposed as properties by `ITelemetryInfo`. The initial set of fields captured are: `SessionFlags`, `SessionLapsRemain`, `SessionNum`, `SessionTimeRemain` and `SessionUniqueID`. A second difference is that the playback speed is much higher than the capture data rate. 

Additionally there are several interfaces and fakes introduced to facilitate unit test construction. While this goal is achieved, it does add more boilerplate and complication to the normal use case code. This layer may be encapsulated outside of the RaceAdmin codebase itself in the future.

## Run in Debug Mode
When the app is run in debug mode from Visual Studio, some helpful features are enabled that are not present in Release Mode.

### Main Tab

On the main screen you'll notice a few differences from the release version:

![race admin screenshot](/images/race-admin-debugMain.png)

### 1. Tab Control 
There is now a Main tab, which functions identically to the release version, and a debug tab which is shown below.

### 2. Populate Incidents Button
Pressing this button will simulate the incidents of a 24 hour race that began 24 hours ago and ended now. This can be used to populate the table with some test values and test filtering functionality, color highlighting, layout changes, etc. See code comments to see how to change the time frame of the simulated session.
Do not use this button if a real iRacing session is in progress.

### Debug Tab

On the debug tab there is another table that displays live information on all cars in the session.

![race admin screenshot](/images/race-admin-debugDebug.png)

### 1. Tab Control 
There is now a Main tab, which funtions identically to the release version, and a Debug tab which is shown here.

### 2. Settings
* Telemetry Poll Rate: This changes the rate at which the app will poll the live telemetry and retrieve updated information. The default value is 4 (Hz) which means the app will update live information 4 times per second. This value can be set to anywhere in the range of 1-60. NOTE: Setting this value too high can adversely affect performance.
* Hide NotInWorld: Enabling this check mark will hide all cars that have a Track Surface value of 'NotInWorld' which means that the car is not in the world and physics are not applying to this car. This value is very common for drivers that have not entered their cars yet, or drivers have exited their cars and gone into the garage to make changes and have not re-entered the world yet.
	
### 3. Debug Table
This table tracks any live/session info the app is tracking for all cars in the session. As cars join the session, cars are added to this table and are never removed, even if the driver disconnects. The columns are:

* CarIdx: The CarIdx number assigned to this car by iRacing in the telemetry.
* Car Number: The car number.
* Position: The overall position of this car.
* Class Position: The in-class position of this car.
* Class: The CarClassShortName of this car assigned by iRacing.
* Driver Name: The name of the current driver of this car.
* % Around Track: The progress of this car around the track given as a percent (0-100%). This value resets to 0% when the car crosses the start/finish line.
* Pit Cones: A pit cone image indicating if this car is currently between the pit cones on pit road. Pit cone image will be an orange color when true, pit cone will be grey when false.
* Current Lap: The current lap in progress of this car.
* Laps Completed: The number of completed laps of this car.
* Track Surface: A TrackSurfaces enum value from telemetry that indicates the current general state/location of the car. Values can be OnPitRoad, NotInWorld, OnTrack, ApproachingPitRoad, etc.
* Track Surface Material: A TrackSurfaceMaterials enum value from telemetry that indicates the current material that the car is in contact with. Values can be Asphalt1Material, Contrete1Material, Rumble1Material, AstroTurfMaterial, Grass3Material, etc.

## Command Line Options

While RaceAdmin normally runs as a simple form and processes live session and telemetry updates from iRacing, it also offers the ability to record and playback session data. This is a recent addition and is not fully mature. It's intended purpose is to allow users to record the session/telemetry data so that it can be used to debug program issues or to aid in new feature development. 

Available command line options:
```
RaceAdmin [options] [command]

Options:
  --version         Show version information
  -?, -h, --help    Show help and usage information

Commands:
  record                Record session updates and telemetry.
  playback <logfile>    Play back only events from the indexed session within the session log.
```
The output session log file is written into the current user's documents folder. The session log filename when recording will be `race-admin-session-<iRacingSessionID>.bin`. When using the playback command, the full path to the session log should not be specified, only the filename itself.