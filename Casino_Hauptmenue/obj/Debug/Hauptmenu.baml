   M S B A M L   `   `   `  ����L  HCasino_Hauptmenue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Casino_HauptmenueCasino_Hauptmenue  5   	   _ [WebEye.Controls.Wpf.WebCameraControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullgOclr-namespace:WebEye.Controls.Wpf;assembly=WebEye.Controls.Wpf.WebCameraControlWebEye.Controls.Wpf 5   	   !    Casino_Hauptmenue.Hauptmenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Casino_Hauptmenue     5   	   _camOclr-namespace:WebEye.Controls.Wpf;assembly=WebEye.Controls.Wpf.WebCameraControl     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 	Hauptmenu��5   	   $
��1024��6   $
��1280��6)    � WindowState$ 	Maximized=�66   ��5      �� 5   
    �� ImageSource$ ./Image/Bild11.jpg��6   .��5      � .+�5   
   � $��245,50,218,172q�6   .+�5      *  $WebEye.Controls.Wpf.WebCameraControl  -   5        $��
CamControl��5   #   $y�Hidden=�65   $��195,10,245.2,413.6q�6I   5      �� 5    
   -   5         ��Name$ cbxcam��5    (   $y�Hidden=�6   $
��Left=�68   $��1101,939,0,0q�6S   $	��Top=�6i   $	��120��6�   �� 5"   
   .+�5#      �� -   5         ��Name$ iBack��5#      $
��Left=�6$   $��55��6?   $��0q�6K   $	��Top=�6V   $��55��6n   $��Image/logout.png��6y    �� Left$ 14��6�   
	 �� Top$	 10��6�   6�   �� 5$      -   5        $ btnMute��5$      $
��Left=�6%   $��55��6@   $��0q�6L   $	��Top=�6W   $��55��6o   $��Image/Volume_On1.png��6z   $ 14��6�   $	 69��6�   $y�Visible=�6�   6�   �� 5%      -   5        $ 	btnMuteOn��5%      $
��Left=�6'   $��55��6B   $��0q�6N   $	��Top=�6Y   $��55��6q   $��Image/Volume_Off1.png��6|   $ 14��6�   $	 69��6�   $y�Hidden=�6�   �� 5&      -   5        $ btnInfo��5&      $
��Left=�6%   $��55��6@   $��0q�6L   $	��Top=�6W   $��55��6o   $ 14��6{   $		 128��6�   $��Image/Info1.png��6�   6�   5'      �� 5(   
   -   5        $�� ��5(      $��245,857,899,25q�6   ��5)      �� 5*      .R�5+      � .+�5,      A� $��eliRoulette��5-   ,   $��5��6   ��5.      �� 5/   "   $ Image/03_Roulette.png��6-   51      52      53      55      �� 58   
   -   5        $�� ��58      $��464,857,680,25q�6   ��59      �� 5:      .R�5;      � .+�5<      A� $��eliGlücksrad��5=   "   $��5��6   ��5>      �� 5?   "   $ Image/04_Glücksrad.png��6-   5A      5B      5C      5E      �� 5H   
   -	   5        $�� ��5H      $��685,857,459,25q�6   ��5I      �� 5J      .R�5K      � .+�5L      A� $��eliEscalero��5M   "   $��5��6   ��5N      �� 5O   "   $ Image/05_Escalero.png��6-   5Q      5R      5S      5U      �� 5X   
   -
   5        $�� ��5X      $��901,857,243,25q�6   ��5Y      �� 5Z      .R�5[      � .+�5\      A� $��eliSlots��5]   "   $��5��6   ��5^      �� 5_   "   $ Image/06_Slotmaschine.png��6-   5a      5b      5c      5e      �� 5h   
   -   5        $�� ��5h      $��50,716,1018,192q�6   ��5i      �� 5j      .R�5k      � ��5l      �� 5m      $ Image/07_Highscore.jpg��6)   5o      5p      5r      �� 5s   
   -   5        
 ��Name$
 label1��5s      $��	OvoCoins:��6    $
��Left=�64   $��989,779,0,0q�6O   $	��Top=�6d   $	��130��6|   ���	#FFFFFEFE$��Arial)�6�   $��24(�6�   $
��Bold"�6�   �� 5t   
   -   5        $
 lblOvocoins��5t      $��0��6%   $
��Left=�61   $��1124,779,0,0q�6L   $	��Top=�6b   $	��124��6z   ���	#FFFFFEFE$��Arial)�6�   $��24(�6�   $��RightToLeft=�6�   $
��Bold"�6�   �� 5u   
   -   5        $ image��5u      $
��Left=�6   $��76��6:   $��1083,703,0,0q�6F   $	��Top=�6\   $��93��6t   $��Image/08_Kamera.png��6   6�   �� 5v   
   -   5        $��cLogin��5v      ���	#7F0C0C0C$	��314��66   $	��100��6B   $y�Hidden=�6O   $��Center=�6c   $��507,462,459,462q�6�   .+�5w      �� -   5        $
 lblLogin��5w      $�� ��6&   $ 10��61   $	 10��6B   $	��305��6R   
���������6^   Z� 6t   �� 5x      -   5         ��Name$ button��5x      $��Ok��6%   $	 114��62   $	 70��6D   $��75��6T   6_   5z      5{      5}      