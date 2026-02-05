# DIG4714-DND-HP-Calculator-Lab
Over the course of a few lab sessions, we are assigned a small project with the aim of creating a Dungeons and Dragons 5E HP Calculator. 
Note to self, delete later: using Unity 2022.3.62f2
### Thought Process
I am using a dictionary to store the class names and associated hit die where class name is the key and die is the value, and an int array to store CON modifiers, where the index is the constitution score. 
I'm going to use an hp calculator method and then call that method in Start(). First check is to see if the user wants the HP averaged or rolled. 

For averaged: call helper method to return float value of the average, where the method takes the class' hit die as a parameter. That result will be multiplied by character level, and then that will be added with (constitution modifier * level). 

