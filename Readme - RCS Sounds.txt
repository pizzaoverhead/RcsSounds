-------------------------------------------------------------
 RCS Sounds
 Author:    pizzaoverhead
 Version:   4.2
 Released:  2014-10-10
 KSP:       v0.25

 Thread:    http://forum.kerbalspaceprogram.com/threads/52896
 Licence:   GNU v2, http://www.gnu.org/licenses/gpl-2.0.html
 Source:    https://github.com/pizzaoverhead/RcsSounds
-------------------------------------------------------------

RCS Sounds adds sound and light effects when firing RCS thrusters. Check the forum thread for updates:
http://forum.kerbalspaceprogram.com/threads/52896

This plugin makes use of ialdabaoth and Sarbian's Module Manager to avoid needing part.cfg edits. Check here for new versions:
http://forum.kerbalspaceprogram.com/threads/55219


Installation
------------
Extract the zip to the root KSP folder, merging with the GameData folder.


Changing the sound files
------------------------
RCS Sounds uses two sound files: rcsSoundFile and rcsShutoffSoundFile. The first is the continuous sound that plays while firing RCS. The second is played when RCS stops firing. By default, it is a fading away of the first sound, but it can also be used for the sound of valves closing for example.
These files can be replaced as follows:

Add the new file(s) into the following directory:

	KSP/GameData/RcsSound/Sounds

Edit ModuleManager_RcsSounds.cfg (found in GameData\RcsSounds\) using the new sound effect to reference the new name.
For example, if your new sound file is called myRcs.wav, change:

	rcsSoundFile = RcsSounds/Sounds/RCSnoise

to:

	rcsSoundFile = RcsSounds/Sounds/myRcs

Note that neither the file extension (.wav) nor "quotation marks" should be included.


Disabling the lighting effects
------------------------------
Edit ModuleManager_RcsSounds.cfg (found in GameData\RcsSounds\) and change
	
useLightingEffects = true
to:
	
useLightingEffects = false


Version history
---------------
4.2 (2014-10-10)
- 0.25 support.
- Upgraded to Module Manager 2.5.1.

4.1b (2014-09-25)
- Added Module Manager licence.
- Upgraded to Module Manager 2.3.5.

4.1 (2014-07-29)
- 0.24.x support.
- Upgraded to Module Manager 2.2.0.

4.0 (2014-04-04)
- Fixed internalRcsSoundsOnly not working correctly.
- Rebuilt for the ARM pack (KSP 0.23.5).
- Updated to ModuleManager 2.0.1.

3.2 (2014-03-09)
- Fixed light effects not being disabled when the thruster runs out of fuel (thanks to BigNose for the bug report).
- Removed old sound file.

3.1 (2014-01-19)
- Fixed debug text appearing in the output log (thanks to Tabakhase for the bug report).

3.0 (2014-01-15)
- Removed dependencies on resources and the replacement of ModuleRCS.

2.0 (2014-01-10)
- Added improved sounds by Daishi.
- Added shutoff sound.
- Added light to the RCS effects (thanks to taniwha for providing some pointers on this).
- Upgraded to ModuleManager 1.5.6.
- Fixed sounds continuing to be played on pause.
- Fixed multiple simultaneous RCS firings resonating together.
- Fixed sounds continuing to play quietly while idle with SAS and RCS enabled.
- Fixed .NET target version.

1.1
- Added support for KSP 0.22. Should work with any future 0.22 patches also.
- Now using ialdabaoth's ModuleManager and sarbian's ModuleManager Extension. This means that you no longer need to edit part.cfgs to add RCS sounds to parts, stock or modded (assuming they use ModuleRCS). Thanks to mwlue for help with setting this up.
- Added the option to only hear RCS sounds in internal views.
- Added the option to make the volume fade off at low thrust values.
- Fixed sound path issue (paths shouldn't be wrapped in quotation marks).

1.0 (2013-10-15)
- Initial release.