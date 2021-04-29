## Week one

Going through my project idea as it stands it was not specific enough, as such I was suggested to make the idea more specific and streamline, I read related content as the research for the project can be narrowed down.

After reading the paperers I found. The project idea was more Pacific but still not narrowed down enough, as it still had too many ideas combined. So I needed to further narrow it down.

## Week two

I decided to change my proposal idea, as the idea in question might not have been that motivating to do as time passed than I previously thought it would.

As such I reaserched into something else the I could use as the new idea. Gating through some things I found an article about skills being improved with action video games, I diced that seamed interesting to do, and I gathered the background information for the new idea and created a second proposal.

The proposal I created was good but not pinpointed to my idea in specific areas of the proposal and wording, I also needed to remove and change around some text as it was placed in wrong area.

## Week three

I Added the changes that where suggested, extending the doc’s information by adding a begging paragraph, added more details to how the project will be more outlined, and fixed up the miner points. 

I was suggested to move a section that can go into another section, checked my spelling, add more references and link them back to what is beaning said.

## Week four

I wanted to get a better undertaking about few more things, regarding hand information and the things to consider when it came to reaction time and motor skills; and if anything, else that I could add to the current research I have. I found two different academic pappies, one looking more into motor skills and reaction time and the other regarding hand-to-hand information transfer related to befits in motor skills with repeated practise.

I looked online to find options for storing and collecting data on Unity. I found a few files formats, such as Jason or xml but thee not as secure and can be changed really easily. The other option I found was binary files, which is secure, but that dose means the file can only be read through the Unity once’s it has been decrypted.

As such a format file might be the option to use at the time bearing, but still look around if I can find nether options.  

## Week five

I read the two other papers I found to get more inflation in the subject I’m investigating.

The Papp ‘BDNF Val66Met polymorphism is associated with abnormal interhemispheric transfer of a newly acquired motor skill’ mention as time passes the more motor training that is taken part in, less mental possessing is done, and it became more reflexive overtime. The two groups they used to conduct the if motor skill can be improved with reptation showed that eventually both group’s motors skill levels managed to be at the same level when it came to small tasks.

 The paper mentions that as the testers dormant is always motor leering they had less proboles with the test then with their other hand, which led to the testers using more mental possessing compared to their dormant hand. The papa ere dose say that the skills acquired from doing the specific test does not mean that the skills will transferer to otherer tasks, if there where to transfuse it would still take some time to reach the same level rate.

The papa per did tall about how different sex could have a effect on how motor skill leering could dirtier, however with the gathered participants they had it was difficult to deduce if that could be a possibility.

This paperer testing process is similar to the test I’m trying conduct; both have areas pf getting information through key press and as sequential patterns and have some randomised sections; however, the approach is slightly applied differently. Conacring how this was taken place maybe the test I’m conducting might need to slight change to get better results.

“Neurophysiological Mechanisms Involved in Transfer of Procedural Knowledge”

I found and read a paper on hand-to-hand transfer skills through reptation with inputting data using keys, to better understand and consider possible factors regarding my test.

The paper ‘had Neurophysiological Mechanisms Involved in Transfer of Procedural Knowledge’ studied that if training with one hand would lead to collected inflation witch then can be transferred to the other hand and thus leading improvements to both hands through repeated motor leering.

Even though this paper says the motor skill inflation can be transferred between hands but only after training, given how my test is also related to get information from inputted keys I should restrict the users to their dominant hand to get the best possible information and also means that the other hand doesn’t need taken in account of in any of results.

I created a reop on github to store the Unity game for this project. I downloaded the stammered assets pack from Unity that as some 2d assets I can use in the game. I built a simple scene to test the assets.

## Week six & Seven

Using the unity’s asset pack, I took some of the 2d assets that where inculked as the place holders for the basic game functionality. I got three platforms to move backwards, the assets provide where made slightly made incorrectly witch I need to fix and found out that the grid individual is 100 x 100 in dimensions which is good to know when I will need to make my own assets.

I added jumping based on a key press for the charter sprite that I’m using t temporary and got an object that moves like the platforms to act like an obstacle to jump over. The obstacle is triggerable, when the character triggered the obstacle’s collider the character rotates and should stop after rotating twice, but it’s doesn’t as I’m unclear how unity uses the Euler angle in degrees or radians, and need figure out which it is.

## Week Eight

I managed to figure out what was going wrong with the Euler angles and the rotation to work the way I wanted. I what the character to rotate twice if the play doesn’t dodge in time and the rotation is in range of -360 to 360 with zero being the starting point, as such having the code check if it has reached the rotation value of 720 wouldn’t work, instead I set up a simple counter to check how many times the character has rotated and once the given amount of 2 is reached the rotation stopes. 

I was going to also setup the time for how long the player has to input the right key to enable a jump to happen. However, putting the timer in the update might not the best idea for example if a process is taking its time the timer could be inaccurate by either it being too fast or being behind as such giving and recording misleading information. I thought I might have to use multi threshed processing, but I found that Unity isn’t multi thread safe. I found that could use IEnumerator and Coroutines to get asynchrony type functionality.

## Week Eight

I managed to figure out what was going wrong with the Euler angles and the rotation to work the way I wanted. I what the character to rotate twice if the play doesn’t dodge in time and the rotation is in range of -360 to 360 with zero being the starting point, as such having the code check if it has reached the rotation value of 720 wouldn’t work, instead I set up a simple counter to check how many times the character has rotated and once the given amount of 2 is reached the rotation stopes. 

I was going to also setup the time for how long the player has to input the right key to enable a jump to happen. However, putting the timer in the update might not the best idea for example if a process is taking its time the timer could be inaccurate by either it being too fast or being behind as such giving and recording misleading information. I thought I might have to use multi threshed processing, but I found that Unity isn’t multi thread safe. I found that could use IEnumerator and Coroutines to get asynchrony type functionality.  
 
## Week nine & ten Christmas brake

When coding on Unity impending the timer and getting object to be colligable apone the timer running out, I resales that the  amount of time I had gathered from research for hum reaction time was too long even more so when multiplied by 2, which defeated the purpose of trying to simulate video game fats past reactions, so by a few trial and error by me putting in numbers, I think having 5 seconds of time seamed right as I was able do it under 3 seconds but I also have to take in account of the non-video game players that I will also asking to take part in my study.

I also thought it and about having the timer go up would be better to record and witch makes sense to see the information; and my fist idea had me only me checking the difference between the first record and the second, but I was subjected that it could better having a bunch of attempts, and I was concerned about the information being difficult make scene if there were too many,  thinking more about having multiple attempts is better but limiting to them to something like 10, so that the person doing the study doesn’t lose intense and thus making the exponent a failure.

## Week eleven & twelve 

Putting the Unity project on hold for now, I spent the time writing the work in progress documentation. This included the report, the participation information sheet, consent form and the privacy policy. Though given the COVID-19 pandemic, getting the participants to fill out documentation and retrieve them back has to be handled a bit differently. I made sure to include this in the forms, so the participants are aware of this.

As I was filling out some of the information, I realized that I needed to consider what exactly the participants need to avoid so the study doesn’t become invalid, like not drinking alcohol that would impede their results. Even though my study involves very low risk, I needed to make sure that the way the participants take part, minimizes or prevents any risk. So, instructing the participants on how to take a uniform way but keeping mind doing it in their own way, so that I would get the best results, was needed to be considered.

I realized that I didn’t include that the participants should get at least a recommended amount of sleep, so that they body, and mind is in peak shape.

## Week thirteen
 
I put the program/game on hold to complete the work in progress document. I had to include what I’m doing and why or what lead me to doing the way I’m doing the project. 
 
Also because I am planning on using human participants, I also needed to include appendixes which included the information sheet, consent form and privacy notice.
 
After it was complete, I sent it off and when back to building the program.
 
## Week fourteen
 
I spent a few days coding to get the inputs with interaction right as an alfa build, which then can be refined and improved later. 
 
I decided to have three different inputs witch would show up in order one at a time, repeating 12 times in a row. The player would be prompted to press the key for a dodge action to happen. The keys would be randomly generated only once when the program starts up. 
 
After the main concept was done, to display the information on screen I linked them with text fields.
 
After I started on the script for the demo video that was coming up the following week. It took some time trying to fit everything under 2 minutes and I managed to miss some information out and not explain things correctly, which led to a lot questions about the project on the day of showing the video.
 
I was also given feedback to see other types of studies to find how they have done their results for motor skill gathering, as the way I am doing it might not lead me to gatherer the correct information.

## Week fifteen

From the feedback received I started to make the changes but randomly a problem occurred with Visual studio, and all of the changes I had made where reverted to when Visual studio program was opened last. Unity also gained a problem as having scripts issues even though there aren’t any. So, I need to fix these issues before I can get the program to be built.

## Week sixteen

This week I managed to fix the issue that I was having with Unity working with Visual studio, by upgrading both visual studio and building the Unity project to the latest version. Doing this and fixing some code problems I managed to get the project to run again.

I first switched out how the input would be handled, with 10 attempts instead of 12, every key will be randomised instead of three re-occurring keys, and I decided to only have one type of action the jump rather than two.

I also displayed the key that needs to be inputted in a text field, that shows up and disappears depending the input time.

I was suggested that to have the input move with the object that needs to dodge, having the inputs feel like a part on the game instead of it being a bit disengaged, making the experiment look like a game useless.

## Week seventeen

Taking feedback from last week, I changed the text field that showed what input needs to be pressed to be images instead, and I got them to follow the object(s) to dodge.

I Implemented a way to store information on local disc and made a quick end screen that shows all scores results. I made the scripts that stores data to store two types of data, the first will store the result that will be sent as part of my research data, this won’t change after the experiment has been completed and the other is the data that collects the changing (high score) results as part of the game loop. I did make so both results can be seen from the game end screen.

I also set up an outline of the UI structure with a; start, pause, scores and quit screens with some of the button’s functionality working.

## Week eighteen

There was a problem with how the images would scale  along with the window size, this was easily fixed by simply clicking on a check box in the canvas settings. I also exported the images again with twice the resolution so when the program runs a higher resolution screens images wouldn’t be blurry.

I also added announcement texts, that showed ‘Ready’ and ‘Go’ texts before starting the testing in the program. 

I was planning on animating the two texts based on a timer, the texts would scale and fade in fast, then slow down while still scaling and then fade out with scaling fast, based on the option set in the editor. I also had it where I could control witch direction the text would scale to, however I couldn’t get scaling and fading to work autumnally the way I wanted based on a timer limit. 

I Instead decided to have it all be control from the editor; the scale starting and ending positions, the point in witch the scaling would slow down and speed back up, the fading in and out speed along with the scaling speed, still keying witch direction to scale to, and removed the timer that was meant to have been the bounds for the two texts’ interactions.

 I found that I was over engineering the solution where to the point I was wasting time trying to get this small interaction to work.

## Week nineteen/twenty

I found that it would be good to added a wait timer before the announcement texts would show up.

I Also ad all of the other remaining functionality to the buttons that need it so, and now I have a game loop, where the participants can ever go back to main menu play again or quit.

I also added the results with an average, based on what they scored.

To show what the users is going to do I added practice round before the actually starting the attempts, so they have time to familiarise them selves with the flow of the game play.

As my program is going to tell the users what to expect I created info cards, that will explain how the game  will be played, along side with the practice round. 

After the practice attempt have be done another info cards pops up, confirming before actually taking the test, pressing the ‘Start’ button will then start the attempts. If the program is played the first time the practice round will have to be played, afterwords a button can be pressed   in the main menu if the player wants to practice again.

After collecting the results form the play a final info cards pops up that thank the user for taking part.

## Week twenty one

I was suggested that the text of the info cards should be re-written and is bit unclear at some points, there are to many of them with a lot of jargon that isn’t needed or could be rewritten, so I need to change the info cards to be more clearer on what is to be expected form the user.

I was told that it would be good to have more then one attempt, so I made it two instead, I was going to make it three but I thought that that might be too many. This based off the rule of three, as when a person is told do something more ten three times repeatedly in a row they might get bored or not have the motivation to do it, so having a gap in between might not make them thing that way.

Continuing off the same  thinking, I thought it would be best to have the objects to dodge also be different, so I made it that they  would also be randomise after each round, this include practice rounds as well.

I quickly added sprite animations to the character for running, jumping and getting it. There was issues where the animation would be delayed when activated, but that was fixed quickly by changing the animation transition speed in the animation’s settings.

## Week twenty two / twenty three - Easet brake


The program has been completed, with custom sprite assets added for backdrops, buttons and small backdrop effects, along with even more objects that the player can interact with.

From the feedback about the information cards, I rewrote them and made them clearer. I also added images to go with the text as secondary explainers.

While I was going through the Unity’s analytics system on how to use it. I learned that it doesn’t quite have the level of control with results finding I’m looking for as previously thought, interns of handling the system with how I want to use it, as such I decided not to use Unity’s analytics and simply ask the participants to take a screen shot or a picture that can be sent to me.

To make the process of informing and collecting information as simple as possible, I made a shared OneDrive folder that holds all of the information that the participants need to know about and the consent form that they need to fill in. I also created folders for the participants to store their results and consent forms and added a read me pdf to explain everything to the participants.

## Week twenty four / Submition

Gathered some participants that where willing  to be a part of the experiment. Collected the results for the OneDrive and made them into tables and graphs that can be place into the report. 

Wrote up a draft of the report and got some feedback. Polished up the report and submitted it along with the video.
