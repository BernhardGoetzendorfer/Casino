   M S B A M L   `   `   `  ����I  ESlot_Animation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Slot_AnimationSlot_Animation  5   	   &     Slot_Animation.SlotMachine_Final   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Slot_Animation     5   	     � Title$  SlotMachine FINAL��5      $
��1024��6%   $
��1280��63    � WindowStyle$
 None=�6@    � 
ResizeMode$ NoResize=�6S    � WindowStartupLocation$ CenterScreen=�6i   ��5	      �� 5
   
    �� ImageSource 5      �� 5       �� 	UriSource$ Resources\S.jpg?�6   5      .��5      � -   5        $��grid1��5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��115 �6   �� 5      $��70 �6   �� 5      $��50 �6   �� 5      $	��220 �6   �� 5      $��42 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��230 �6   �� 5       $��40 �6   �� 5!      $��50 �6   �� 5"      $	��230 �6   �� 5#      $��50 �6   �� 5$      $��35 �6   �� 5%      $	��230 �6   �� 5&      $��1* �6   .+�5(   
   �� -   5        $��slot1��5(      $	��840��6   $	��230��6+   $��1��67   $��4��6G   ��5)      �� 5*      $ Resources\walze.png��5+       j� Viewport$ 0,1,1,1�5,      	 j� TileMode$
	 Tile=�5-      50      �� 51   
   -   5        $��slot2��51      $	��840��6   $	��230��6+   $��4��67   $��4��6G   ��52      �� 53      $ Resources\walze.png��54      $ 0,1,1,1�55      $
	 Tile=�56      59      �� 5:   
   -   5        $��slot3��5:      $	��840��6   $	��230��6+   $��7��67   $��4��6G   ��5;      �� 5<      $ Resources\walze.png��5=      $ 0,1,1,1�5>      $
	 Tile=�5?      5B      �� 5C   
   -   5        $��btnStart��5C      $��7��6!   $��4��6.   $��Start��6>   $��50��6e   $	��130��6q   ���	#FF931D1D
�������
�������$��3q�6�   �� 5D   
   -   5        $��btnAuto��5D      $��8��6    $��4��6-   $��	Automatik��6=   $��50��6Q   $	��130��6]   ���	#FF931D1D
�������
�������$��3q�6�   6�   �� 5E   
   -   5        $��btnStop��5E      $��3��6    $��8��60   $��50��6=   $��50��6I   $
��Stop��6T   ���	#FF931D1D
�������
�������$��3q�6�   6�   �� 5F   
   -   5        $��beschriftung3��5F      $��8��6%   $��8��65   $��	Highscore��6B   $��16(�6V   $
��Bold"�6d   
�������6v   �� 5G   
   -	   5        $��lbHighscore��5G      $��8��6#   $��9��63   $��0��6@   $��16(�6L   $
��Bold"�6Z   
�������6l   �� 5H   
   -
   5        $��beschriftung2��5H      $��7��6%   $��8��65   $��Einsatz��6B   $��16(�6T   $
��Bold"�6b   
�������6t   �� 5I   
   -   5        $��	lbEinsatz��5I      $��7��6!   $��9��61   $��0��6>   $��16(�6J   $
��Bold"�6X   
�������6j   �� 5J   
   -   5        $��beschriftung1��5J      $��1��6%   $��8��65   $��Guthaben��6B   $��16(�6U   $
��Bold"�6c   
�������6u   �� 5K   
   -   5        $��
lbGuthaben��5K      $��1��6"   $��9��62   $�� ��6?   $��16(�6J   $
��Bold"�6X   
�������6j   �� 5M   
   -   5        $��Auswertung2��5M      $��1��6#   $��1��63   
�������$*��$3x                       Einsatz x 5��6S   $��16(�6�   $
��Bold"�6�   $��50��6�   $��	0,38,0,27q�6�   �� 5N   
   -   5        $��Kirsche��5N      $��1��6   $��1��6/   $��50��6<   $��50��6H   $��Resources\cherries.png��6S   $
��Fill=�6s   $��30,38,150,27q�6�   �� 5O   
   -   5        $��Auswertung1��5O      $��1��6#   $��2��63   
�������$+��%3x                       Einsatz x 10��6S   $��16(�6�   $
��Bold"�6�   $��50��6�   $��0,0,0,20q�6�   �� 5P   
   -   5        $��melone��5P      $��1��6   $��2��6.   $��50��6;   $��50��6G   $��Resources\melon.png��6R   $
��Fill=�6o   $��30,0,150,20q�6~   �� 5Q   
   -   5        $��Auswertung3��5Q      $��7��6#   $��1��63   
�������$+��%3x                       Einsatz x 15��6S   $��16(�6�   $
��Bold"�6�   $��50��6�   $��	0,38,0,27q�6�   �� 5R   
   -   5        $	��Bar��5R      $��7��6   $��1��6+   $��50��68   $��50��6D   $��Resources\bar.png��6O   $
��Fill=�6j   $��30,38,150,27q�6y   �� 5S   
   -   5        $��Auswertung4��5S      $��7��6#   $��2��63   
�������$+��%3x                       Einsatz x 20��6S   $��16(�6�   $
��Bold"�6�   $��50��6�   $��0,0,0,20q�6�   �� 5T   
   -   5        $��Seven��5T      $��7��6   $��2��6-   $��50��6:   $��50��6F   $��Resources\seven.png��6Q   $
��Fill=�6n   $��30,0,150,20q�6}   �� 5U   
   -   5        $��bteinsatzplus��5U      $��5��6&   $��8��66   $��+��6C   
�������$��40��6b   $��40��6n   $��16(�6y   $
��Bold"�6�   ���	#FF931D1D
�������$��2q�6�   $��	10,10,0,0q�6�   6�   �� 5V   
   -   5        $��bteinsatzminus��5V      $��5��6'   $��9��67   $��-��6D   
�������$��40��6c   $��40��6o   $��
10,0,0,149q�6z   $��16(�6�   $
��Bold"�6�   ���	#FF931D1D
�������$��2q�6�   6�   �� 5W   
   -   5        $��
btnZurueck��5W      $��Resources/Pfeil.png��6"   $��55��6?   $��55��6J   $��0��6V   $��0��6f   $��22,10,131,122q�6s   6�   �� 5X   
   -   5        $��btnMute��5X      $��Resources/Volume_On.png��6   $��55��6@   $��55��6K   $��0��6W   $��0��6g   $��22,88,131,44q�6t   6�   �� 5Y   
   -   5        $��lblHighscore1��5Y      $�� ��6%   ���	#FFF3C447$��32(�6G   $	��200��6U   $��55��6a   $��7��6m   $��0��6}   $��30,10,10,139q�6�   �� 5Z   
   -   5        $��lblHighscore2��5Z      $�� ��6%   ���	#FFF3C447$��32(�6G   $	��200��6U   $��55��6a   $��7��6m   $��0��6}   $��30,65,10,84q�6�   �� 5[   
   -   5        $��lblHighscore3��5[      $�� ��6%   ���	#FFF3C447$��32(�6G   $	��200��6U   $��55��6a   $��7��6m   $��0��6}   $��30,120,10,29q�6�   �� 5\   
   -   5        $��lblHighscorePunkte1��5\      $�� ��6+   ���	#FFF3C447$��32(�6M   $	��150��6[   $��55��6g   $��8��6s   $��0��6�   $��0,10,34,139q�6�   �� 5]   
   -   5        $��lblHighscorePunkte2��5]      $�� ��6+   ���	#FFF3C447$��32(�6M   $	��150��6[   $��55��6g   $��8��6s   $��0��6�   $��
0,65,34,84q�6�   �� 5^   
   -   5        $��lblHighscorePunkte3��5^      $�� ��6+   ���	#FFF3C447$��32(�6M   $	��150��6[   $��55��6g   $��8��6s   $��0��6�   $��0,120,34,29q�6�   5e      5f      