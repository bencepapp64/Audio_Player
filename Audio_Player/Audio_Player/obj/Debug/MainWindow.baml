   M S B A M L   `   `   `  ����G  CAudio_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Audio_PlayerAudio_Player  5   	       Audio_Player.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Audio_Player     5   	     � Title$  Audio_Player by: Bence��5   	   $	��500��6(   $	��500��65    � 
ResizeMode$ CanMinimize=�6A   .��5	      � .+�5
   
   �� -   5         ��Name$ List_Box��5
      $
��Left=�6$   $	��222��6?   $��
100,60,0,0q�6L   $	��Top=�6`   $	��300��6x   6�   �� 5   
   -   5         ��Name$ M_Slider��5      $
��Left=�6#   $��100,318,0,0q�6>   $	��Top=�6S   $	��300��6k    J� RenderTransformOrigin$ 0.523,3.278&�6w   6�   �� 5   
   -   5         ��Name$ previous��5      $��<<��6#   $
��Left=�66   $��100,350,0,0q�6Q   $	��Top=�6f   $��50��6~   6�   �� 5   
   -   5        $
 next��5      $��>>��6   $
��Left=�62   $��350,350,0,0q�6M   $	��Top=�6b   $��50��6z   6�   �� 5   
   -   5        $
 Play��5      $��Play / Pause��6   $
��Left=�66   $��200,350,0,0q�6Q   $	��Top=�6f   $	��100��6~   6�   �� 5   
   -   5        $ V_Slider��5      $
��Left=�6#   $��
262,23,0,0q�6>   $	��Top=�6R   $��18��6j   $ 0.5,0.5&�6v   $	��150��6�    � Maximum$ 1Q�6�    � LargeChange$	 0.1Q�6�    � SmallChange$ 1Q�6�   z�5      V� 5      .~�5      �� 	 �� ScaleY$	 -1Q�6%   �� 5      �� 5      T� 5      5      5      �� 5   
   -   5        $
��Open��5      $
��Left=�6    $��325,262,0,0q�6;   $	��Top=�6P   $��75��6h   6s   �� 5   
   -   5        $
��Save��5      $
��Left=�6    $��
110,22,0,0q�6;   $	��Top=�6O   $��75��6g   6r   �� 5   
   $��423,22,44,427q�6   $��
Image3.png��6'   $
��Fill=�6;   �� 5   
   $��224,22,247,427q�6   $��
Image4.png��6(   $
��Fill=�6<   $ 0.84,0.5&�6K   �� 5   
   -	   5        $��Open ��5      $
��Left=�6!   $��	10,22,0,0q�6<   $	��Top=�6O   $��75��6g   6r   �� 5   
   $
��Now:��6   $
��Left=�6   $��100,282,0,0q�6:   $	��Top=�6O   $��31��6g   $��14(�6s   $��50��6�   �� 5   
   -
   5        
 ��Name$	
 Now��5      $�� ��6   $
��Left=�6(   $��150,282,0,0q�6C   $	��Top=�6X   $	��250��6p   $��31��6|   5!      5"      