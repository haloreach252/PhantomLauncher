   M S B A M L   `   `   `  ����M  IPhantomLauncherGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PhantomLauncherGUIPhantomLauncherGUI  5   	   #    PhantomLauncherGUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:PhantomLauncherGUI     5   	   -   5          � Title$  Phantom Launcher��5   	   $	��720��6"   $
��1280��6/    � 
ResizeMode$ NoResize=�6<    � WindowStartupLocation$ CenterScreen=�6R    � WindowStyle$
 None=�5	   	    � AllowsTransparency . $!��BIGMACCA, ./Fonts/#BIGMACCA)�5
   	   $��14(�62   ���	#FF292929���	#FFC1C1C1 � WindowState$ Normal=�5   7   .��5      � .+�5   
   �� -   5         ��Name$ titleBarBackground��5      ���	#FF383838$
��Left=�6A   $��25��6\   $	��Top=�6h   $
��1280��6�   6�   �� 5   
   -   5         ��Name$ titleBarTitle��5      $��Phantom Launcher��6'   $
��Left=�6B   $	��Top=�6]   $��20(�6u   ���	#FFC1C1C1
 � Tag$ resize��6�   �� 5   
   -   5        	 ��Name$	 exitApplicationButton��5      $��joint��60   $��Right=�6@   $��0,0,0,0q�6\   $	��Top=�6m   $��25��6�   $��25��6�   $(��"./Fonts/#Font Awesome 5 Free Solid)�5      $��12(�6=   $
 exit��6c   �� 5   
   -   5        $	 maximizeApplicationButton��5      $��cannabis��64   $��Right=�6G   $��0,0,25,0q�6c   $	��Top=�6u   $��25��6�   $��25��6�   $(��"./Fonts/#Font Awesome 5 Free Solid)�5      $��12(�6=   $ maximize��6g   �� 5   
   -   5        $	 minimizeApplicationButton��5      $
��bong��64   $��Right=�6C   $��0,0,50,0q�6_   $	��Top=�6q   $��25��6�   $��25��6�   $(��"./Fonts/#Font Awesome 5 Free Solid)�5      $��12(�6=   $ minimize��6g   �� 5   
   -   5        
 ��Name$
 contextBarContent��5      $
��1280��64   $��70��6A   $
��Left=�6M   $	��Top=�6h   $��0,30,0,0q�6�   $��Stretch=�5      $��Stretch=�6<   �� 5   
   -   5        $
 mainContentControl��5      $
��1260��65   $	��600��6B   $��10,110,10,10q�6O   $��Stretch=�5      $��Stretch=�6<   5"      5#      