   M S B A M L   `   `   `  ����H  DRoulette0.0.8, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Roulette0._0._8Roulette0._0._8  5   	       Roulette0._0._8.Roulette   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Roulette0._0._8     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � WindowState$ 	Maximized=�5
   	    � Title$ Roulette��5   	   $
��1024��6   $
��1280��6(   .��5      � ��5   
   �� 5       �� ImageSource$  Bilder/Roulette.Finish.jpg��6   .+�5      A� -   5         A�Name$ eliJetonFuenf��5      $��53��6*    �� Left$	 978��66   
 �� Top$	 813��6H   $��52��6Y   $��978,805,242,158q�6�    � Cursor$
 Hand��6�   ��5      �� 5      $ ./Bilder/05.png��6   	 j� Stretch$
	 Fill=�6;   5      A� 5   
   -   5        $ eliJetonZehn��5      $y�Visible=�6(   $��53��6>   $
 1046��6J   $	 813��6^   $��52��6o   $��1041,805,179,158q�6�   $
 Hand��6�   ��5      �� 5      $ ./Bilder/10.png��6   $
	 Fill=�6;   5       A� 5!   
   -   5        $ eliJetonFuenfUndZwanzig��5!      $��53��63   $
 1114��6?   $	 813��6R   $��52��6c   $��1104,805,116,158q�6�   $
 Hand��6�   ��5"      �� 5#      $ ./Bilder/25.png��6   $
	 Fill=�6;   5%      A� 5&   
   -   5        $ eliJetonFuenfzig��5&      $y�Visible=�6,   $��53��6B   $
 1182��6N   $	 813��6b   $��52��6s   $��1166,805,54,158q�6�   $
 Hand��6�   ��5'      �� 5(      $ ./Bilder/50.png��6   $
	 Fill=�6;   5*      A� 5+   
   -   5        $ eliJetonFuenfGewaehlt��5+      $
 Hand��61   $y�Hidden=�6?   $��70��6T   $	 970��6`   $	 804��6r   $��70��6�   $��969,796,233,150q�6�   ��5,      �� 5-      $ ./Bilder/05.png��6   $
	 Fill=�6;   5/      A� 50   
   -   5        $ eliJetonZehnGewaehlt��50      $
 Hand��60   $y�Hidden=�6>   $��70��6R   $
 1037��6^   $	 804��6q   $��70��6�   $��1032,796,170,150q�6�   ��51      �� 52      $ ./Bilder/10.png��6   $
	 Fill=�6;   54      A� 55   
   -   5        $  eliFuenfUndZwanzigGewaehlt��55      $
 Hand��66   $y�Hidden=�6D   $��70��6~   $
 1105��6�   $	 804��6�   $��70��6�   $��1095,796,107,150q�6�   ��56      �� 57      $ ./Bilder/25.png��6   $
	 Fill=�6;   59      A� 5:   
   -   5        $ eliJetonFuenfzigGewaehlt��5:      $
 Hand��64   $y�Hidden=�6B   $��70��6{   $
 1172��6�   $	 804��6�   $��70��6�   $��1158,796,44,150q�6�   ��5;      �� 5<      $ ./Bilder/50.png��6   $
	 Fill=�6;   5>      �� 5F   
   -	   5        
 ��Name$
 lblZahl��5F      $�� ��6!   $��Center=�6,   $��Center=�6P   $
��Left=�6r   $��
534,24,0,0q�6�   $	��Top=�6�   $	��135��6�   $	��212��6�   ���	#FF0E0D0D���	#FFFFF8F8$��80(�6   $
��Bold"�6   J� RenderTransformOrigin$ 0.5,0.5&�6   �� 5O   
   -
   5        $��cvsHintergrund��5O      $��	0,0,0,281q�6'   .+�5j      (� $
��1016��6   $
 -498��6$   $
 -295��67   $
��1272��6I   .��5k      �� -   5         ��Name$ 	cvsKessel��5k      $
��Left=�6,   $	��Top=�6G   $��123,398,0,0q�6_   $	��250��6t   $	��250��6�   $
 Hand��6�   ��5l      �� 5m      $
	 None=�6%   $ ./Bilder/Kessel.png��64   .+�5p      A� -   5        $ eliKesselInnere��5p      $ 34.008��5r      $ 34.167��5s      $��181.151��5t      $	��181��5u      $��1��5v      
���   �$ 0.497,0.496&�5w      $
 Hand��6C   ��5x      �� 5y      $ ./Bilder/KesselInhalt.png��6)   5|      A� 5~      -   5        $ eliKugel��5~      $ 17��5      $	 118��5�      $��10��5�      $��10��5�      $	��0.5��5�      
���   �$ 0.6,10.6&�5�      ��5�      �� 5�      $ ./Bilder/Kugel.png��6)   5�      5�      5�      � 5�      -   5         �Name$ polFeld0��5�       � Points3 �   ��C@���
@���
 H�@���[ 
������ $	 457��5�      $	 354��6   $��79��6(   $	��252��64   $ 0.5,0.5&�6@   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�       �� Angle$ -90.191Q�6*   T� 5�      5�      5�      �� 5�      
���   �$��55��6)   $
 1006��65   $	 944��6H   $	��242��6Y   ��5�      �� 5�      $ ./Bilder/wasauchimmer.png��6!   5�      �� 5�      -   5        $ cvsEins��5�      ���	#FFEA2626 J� Opacity$ 0Q�6=   $��59��6I   $	 520��6U   $	 563��6g   $��48��6x   
 � Tag$ 1��6�   �� 5�      -   5        $ cvsZwei��5�      ���	#FFEA2626$ 0Q�6=   $��59��6I   $	 520��6U   $	 502��6g   $��48��6x   $ 2��6�   �� 5�      -   5        $ cvsDrei��5�      ���	#FFEA2626$ 0Q�6=   $��59��6I   $	 520��6U   $	 440��6g   $��48��6x   $ 3��6�   �� 5�      -   5        $ cvsVier��5�      ���	#FFEA2626$ 0Q�6=   $��59��6I   $	 569��6U   $	 563��6g   $��48��6x   $ 4��6�   �� 5�      -   5        $ cvsFuenf��5�      ���	#FFEA2626$ 0Q�6>   $��59��6J   $	 569��6V   $	 502��6h   $��48��6y   $ 5��6�   �� 5�      -   5        $ cvsSechs��5�      ���	#FFEA2626$ 0Q�6>   $��59��6J   $	 569��6V   $	 440��6h   $��48��6y   $ 6��6�   �� 5�      -   5        $ 	cvsSieben��5�      ���	#FFEA2626$ 0Q�6?   $��59��6K   $	 619��6W   $	 563��6i   $��48��6z   $ 7��6�   �� 5�      -   5        $ cvsAcht��5�      ���	#FFEA2626$ 0Q�6=   $��59��6I   $	 619��6U   $	 502��6g   $��48��6x   $ 8��6�   �� 5�      -   5        $ cvsNeun��5�      ���	#FFEA2626$ 0Q�6=   $��59��6I   $	 619��6U   $	 440��6g   $��48��6x   $ 9��6�   �� 5�      -   5        $ cvsZehn��5�      ���	#FFEA2626$ 0Q�6=   $��59��6I   $	 669��6U   $	 563��6g   $��48��6x   $ 10��6�   �� 5�      -   5        $ cvsElf��5�      ���	#FFEA2626$ 0Q�6<   $��59��6H   $	 669��6T   $	 502��6f   $��48��6w   $ 11��6�   �� 5�      -   5        $ 	cvsZwoelf��5�      ���	#FFEA2626$ 0Q�6?   $��59��6K   $	 669��6W   $	 440��6i   $��48��6z   $ 12��6�   �� 5�      -   5        $ cvsDreiZehn��5�      ���	#FFEA2626$ 0Q�6A   $��59��6M   $	 725��6Y   $	 563��6k   $��48��6|   $ 13��6�   �� 5�      -   5        $ cvsVierZehn��5�      ���	#FFEA2626$ 0Q�6A   $��59��6M   $	 725��6Y   $	 502��6k   $��48��6|   $ 14��6�   �� 5�      -   5        $ cvsFuenfZehn��5�      ���	#FFEA2626$ 0Q�6B   $��59��6N   $	 725��6Z   $	 440��6l   $��48��6}   $ 15��6�   �� 5�      -   5        $ cvsSechsZehn��5�      ���	#FFEA2626$ 0Q�6B   $��59��6N   $	 775��6Z   $	 563��6l   $��48��6}   $ 16��6�   �� 5�      -   5        $ cvsSiebZehn��5�      ���	#FFEA2626$ 0Q�6A   $��59��6M   $	 775��6Y   $	 502��6k   $��48��6|   $ 17��6�   �� 5�      -    5        $ cvsAchtZehn��5�      ���	#FFEA2626$ 0Q�6A   $��59��6M   $	 775��6Y   $	 440��6k   $��48��6|   $ 18��6�   �� 5�      -!   5        $ cvsNeunZehn��5�      ���	#FFEA2626$ 0Q�6A   $��59��6M   $	 825��6Y   $	 563��6k   $��48��6|   $ 19��6�   �� 5�      -"   5        $ 
cvsZwanzig��5�      ���	#FFEA2626$ 0Q�6@   $��59��6L   $	 825��6X   $	 502��6j   $��48��6{   $ 20��6�   �� 5�      -#   5        $ cvsEinUndZwanzig��5�      ���	#FFEA2626$ 0Q�6F   $��59��6R   $	 825��6^   $	 440��6p   $��48��6�   $ 21��6�   �� 5�      -$   5        $ cvsZweiUndZwanzig��5�      ���	#FFEA2626$ 0Q�6G   $��59��6S   $	 875��6_   $	 563��6q   $��48��6�   $ 22��6�   �� 5�      -%   5        $ cvsDreiUndZwanzig��5�      ���	#FFEA2626$ 0Q�6G   $��59��6S   $	 875��6_   $	 502��6q   $��48��6�   $ 23��6�   �� 5�      -&   5        $ cvsVierUndZwanzig��5�      ���	#FFEA2626$ 0Q�6G   $��59��6S   $	 875��6_   $	 440��6q   $��48��6�   $ 24��6�   �� 5�      -'   5        $ csvFuenfUndZwanzig��5�      ���	#FFEA2626$ 0Q�6H   $��59��6T   $	 931��6`   $	 563��6r   $��48��6�   $ 25��6�   �� 5�      -(   5        $ cvsSechsUndZwanzig��5�      ���	#FFEA2626$ 0Q�6H   $��59��6T   $	 931��6`   $	 502��6r   $��48��6�   $ 26��6�   �� 5�      -)   5        $ csvSiebenUndZwanzig��5�      ���	#FFEA2626$ 0Q�6I   $��59��6U   $	 931��6a   $	 440��6s   $��48��6�   $ 27��6�   �� 5�      -*   5        $ csvAchtUndZwanzig��5�      ���	#FFEA2626$ 0Q�6G   $��59��6S   $	 981��6_   $	 563��6q   $��48��6�   $ 28��6�   �� 5�      -+   5        $ cvsNeunUndZwanzig��5�      ���	#FFEA2626$ 0Q�6G   $��59��6S   $	 981��6_   $	 502��6q   $��48��6�   $ 29��6�   �� 5�      -,   5        $ csvDreissig��5�      ���	#FFEA2626$ 0Q�6A   $��59��6M   $	 981��6Y   $	 440��6k   $��48��6|   $ 30��6�   �� 5�      --   5        $ cvsEinUndDreissig��5�      ���	#FFEA2626$ 0Q�6G   $��59��6S   $
 1031��6_   $	 563��6r   $��48��6�   $ 31��6�   �� 5�      -.   5        $ cvsZweiUndDreissig��5�      ���	#FFEA2626$ 0Q�6H   $��59��6T   $
 1031��6`   $	 502��6s   $��48��6�   $ 32��6�   �� 5�      -/   5        $ cvsDreiUndDreissig��5�      ���	#FFEA2626$ 0Q�6H   $��59��6T   $
 1031��6`   $	 440��6s   $��48��6�   $ 33��6�   �� 5�      -0   5        $ cvsVierUndDreissig��5�      ���	#FFEA2626$ 0Q�6H   $��59��6T   $
 1081��6`   $	 563��6s   $��48��6�   $ 34��6�   �� 5�      -1   5        $ cvsFuenfUndDreissig��5�      ���	#FFEA2626$ 0Q�6I   $��59��6U   $
 1081��6a   $	 502��6t   $��48��6�   $ 35��6�   �� 5�      -2   5        $ cvsSechsUndDreissig��5�      ���	#FFEA2626$ 0Q�6I   $��59��6U   $
 1081��6a   $	 440��6t   $��48��6�   $ 36��6�   �� 5�      -3   5        $ 	cvsGerade��5�      ���	#FFEA2626$ 0Q�6?   $��35��6K   $	 619��6W   $	 626��6i   $��98��6z   6�   �� 5�      -4   5        $ cvsUngerade��5�      ���	#FFEA2626$ 0Q�6A   $��35��6M   $	 930��6Y   $	 626��6k   $��98��6|   6�   �� 5�      -5   5        $ cvsRot��5�      ���	#FFEA2626$ 0Q�6<   $��35��6H   $	 725��6T   $	 626��6f   $��98��6w   6�   �� 5�      -6   5        $ 
cvsSchwarz��5�      ���	#FFEA2626$ 0Q�6@   $��35��6L   $	 825��6X   $	 626��6j   $��98��6{   6�   �� 5�      -7   5        $
 label��5�      $��Punkte:��6#   $
 1018��65   $	 955��6H   $��16(�6Y   ���	#FFFDF6F66g   �� 5�      -8   5        $
 	lblPunkte��5�      $��0��6'   $
 1089��63   $	 955��6F   $��16(�6W   ���	#FFFDF6F66e   �� 5�      
���   �$��55��6)   $	 550��65   $	 944��6G   $	��242��6X   ��5�      �� 5�      $ ./Bilder/wasauchimmer.png��6!   5�      �� 5�      -9   5        $
 
lblEinsatz��5�      $��0��6(   $	 629��64   $	 955��6F   $��16(�6W   ���	#FFFDF6F66e   �� 5�      -:   5        $
 
label_Copy��5�      $��Einsatz:��6(   $	 562��6;   $	 955��6M   $��16(�6^   ���	#FFFDF6F66l   �� 5�      
���   �$��55��6)   $	 778��65   $	 944��6G   $	��242��6X   ��5�      �� 5�      $ ./Bilder/wasauchimmer.png��6!   5�      �� 5�      -;   5        $
 	lblGewinn��5�      $��0��6'   $	 865��63   $	 955��6E   $��16(�6V   ���	#FFFDF6F66d   �� 5�      $��Gewinn:��6   $	 798��6&   $	 955��68   $��16(�6I   ���	#FFFDF6F66W   �� 5�      $��Löschen��6   $	 620��6&   $	 867��68   ���	#FFB4B0B06I   �� 5�      -<   5        $
 lblSchnellStart��5�      $��Schnell Start��6-   $	 715��6E   $	 867��6W   ���	#FFB4B0B06h   �� 5�      -=   5        $
 lblStart��5�      $��Start��6&   $	 840��66   $	 867��6H   ���	#FFB4B0B06Y   �� 5�      ->   5         ��Name$ btnStart��5�      $��80��6&   $	 816��62   $��Bilder/StartButton.png��6D   $
��Fill=�6d   $	 786��6s   $��80��6�   $
 Hand��6�    J� OpacityMask 5�      �� 5�      $ ./Bilder/StartButton.png��6!   5�      �� 5�      -?   5        $ btnEinsatzWiederholen��5�      $��80��63   $	 712��6?   $ ��./Bilder/ZurueckButton.png��6Q   $
��Fill=�6u   $	 786��6�   $��80��6�   $
 Hand��6�    5�      �� 5      $ Bilder/ZurueckButton.png��6!   5     �� 5     -@   5        $ btnEinsatzLoeschen��5     $��80��60   $	 606��6<   $��Bilder/löschenbutton.png��6N   $
��Fill=�6p   $	 786��6   $��80��6�   $
 Hand��6�    5     �� 5     $! ./Bilder/löschenbutton.png��6!   5     �� 5     -A   5        $ 
btnZurueck��5     $
��Left=�6(   $��55��6C   $��0q�6O   $	��Top=�6Z   $��55��6r   $��Bilder/Pfeil.png��6}   $ 14��6�   $ 10��6�   6�   �� 5	     -B   5        $ btnOn��5	     $
��Left=�6#   $��55��6>   $��0q�6J   $	��Top=�6U   $��55��6m   $3��-/Roulette0.0.8;component/Bilder/Volume_On.png��6x   $ 14��6�   $ 69��6�   6�   �� 5
     -C   5        $ btnInfo��5
     $
��Left=�6%   $��55��6@   $��0q�6L   $	��Top=�6W   $��55��6o   $��Bilder/Info.png��6z   $ 14��6�   $	 128��6�   6�   �� 5     
���   �$��55��6)   $	 322��65   $	 944��6G   $	��242��6X   ��5     �� 5     $ Bilder/wasauchimmer.png��6!   5     �� 5     -D   5        $
 lblGuthaben��5     $��0��6)   $	 421��65   $	 955��6G   $��16(�6X   ���	#FFFDF6F66f   �� 5     $��	Guthaben:��6   $	 334��6(   $	 955��6:   $��16(�6K   ���	#FFFDF6F66Y   5     �� 5  
   -E   5        $
 lblHighscore1��5     $�� ��6'   $
��Left=�62   $��
784,14,0,0q�6M   $	��Top=�6a   ���	#FFF3C447$	��266��6�   $��32(�6�   �� 5  
   -F   5        $
 lblHighscore2��5     $�� ��6'   $
��Left=�62   $��
784,67,0,0q�6M   $	��Top=�6a   ���	#FFF3C447$	��266��6�   $��32(�6�   �� 5  
   -G   5        $
 lblHighscore3��5     $�� ��6'   $
��Left=�62   $��784,120,0,0q�6M   $	��Top=�6b   ���	#FFF3C447$	��266��6�   $��32(�6�   �� 5  
   -H   5        $
 lblHighscorePunkte1��5     $�� ��6-   $
��Left=�68   $��1055,14,0,0q�6S   $	��Top=�6h   ���	#FFF3C447$	��180��6�   $��32(�6�   $��Right=�6�   �� 5  
   -I   5        $
 lblHighscorePunkte2��5     $�� ��6-   $
��Left=�68   $��1055,67,0,0q�6S   $	��Top=�6h   ���	#FFF3C447$	��180��6�   $��32(�6�   $��Right=�6�   �� 5  
   -J   5        $
 lblHighscorePunkte3��5     $�� ��6-   $
��Left=�68   $��1055,120,0,0q�6S   $	��Top=�6i   ���	#FFF3C447$	��180��6�   $��32(�6�   $��Right=�6�   5     5      