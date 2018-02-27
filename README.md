# <img src="https://raw.githubusercontent.com/PatPositron/mPanel/master/images/mPanel.png" width="32" height="32"> mPanel

mPanel is a multi-function control panel for my homemade LED matrix

The hardware is comprised of an arduino nano clone controlling 225 Neopixel LEDs in a 15x15 grid

The arduino is running the sketch located in Arduino/matrix

You can connect to an arduino, or connect to the GUI as a preview mode

Once connected, you can begin to use all of the Actions available

## Actions

### Preview and Basic Actions
<img src="https://raw.githubusercontent.com/PatPositron/mPanel/master/images/preview.png">

While you are connected to a matrix, Preview and Basic Actions will always stay open

The Preview form always shows you exactly what is being shown on the matrix

The Basic Actions form allows you to
* Set global LED brightness
* Set all LEDs to a certain color
* Clear the matrix
* Make the matrix go into standby mode

### Animator
<img src="https://raw.githubusercontent.com/PatPositron/mPanel/master/images/animator.png">

The animator allows you to quickly draw things onto the matrix using your mouse cursor

When you click Enable, the animation begins looping with the specified delay inbetween frames

Frames
* There is always 1 frame, but there is no limit to the number of frames
* You can remove a certain frame, or you can change its position in the animation by moving it up and down
* Clearing all frames resets the animation
* Pressing Control + C while editing a frame clones the current frame and automatically selects it

Coloring
* You can set 4 distinct colors to draw with at one time
  * L is left click
  * R is right click
  * LA is Alt + left click
  * RA is Alt + right click
* Shift + any option above clears the entire panel with that color
* Control + left click clears the selected pixel
* Control + right click clears the entire frame

Files
* You can import image files into your animation
  * .png, .jpeg, and .gif are supported (animated .gif files are broken down into multiple frames)
* You can save your animation
  * Animations are serialized into .ma files (changes after you save are not added, you must save again for each change)
* You can load a saved animation
  * This clears your current animation, so save it if you don't want to lose it

### Snake
<img src="https://raw.githubusercontent.com/PatPositron/mPanel/master/images/snake.gif">

Controls
* WASD keys to change direction
* Endless mode automatically adds food to your tail

Key presses are only captured when the Snake form is in focus
The number in the title of the form is the length of your tail

### Pong
<img src="https://raw.githubusercontent.com/PatPositron/mPanel/master/images/pong.gif">

Controls
* Space starts the ball movement
* Top player
  * D key is left
  * F key is right
* Bottom player
  * J key is left
  * K key is right

Key presses are only captured when the Pong form is in focus

### Visualizer
<img src="https://raw.githubusercontent.com/PatPositron/mPanel/master/images/visualizer.gif">

This is a sound visualizer implemented using <a href="https://github.com/filoe/cscore">CSCore</a>

Options
* Use average smooths the bars, make it less jumpy
* Minimum frequency is the lowest frequency that the bars will react to
* Maximum frequency is the highest frequency that the bars will react to
* Amplifier value is multiplied with the calculated bar height to make the bars taller

### Weather
