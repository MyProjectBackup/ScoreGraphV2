   M S B A M L   `   `   `  ����G  CScoreGraphV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ScoreGraphV2ScoreGraphV2  5   	       ScoreGraphV2.ScoreGraph   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ScoreGraphV2     5   	     � Title$  阶段曲线图��5   	   $	��510��6   $	��800��6$    � Icon$ Account.theme-light.ico��60    � 
ResizeMode$ CanMinimize=�6O   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��118* �6   �� 5      $
��377* �6   �� 5      $
��297* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $*��$近十次单科目训练成绩曲线��6!   $��Center=�65   $��18(�6R   $��Bottom=�6`   $��2��6{   $��169.796,0,288,0q�6�   $��1��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��2��6X   $��51.796,0,170,0q�6l   $��1��6�   .+�5      �� $��姓名��6   $��Center=�6!   $��16(�6C   �� 5      -   5         ��Name$ 
Users_Name��5      $	��100��6*   $��20��66   $��Center=�6B   $��Right=�6]   $��0,0,10,0q�6y   �� 5      $��训练科目��6   $��Center=�6#   $��16(�6E   �� 5      -   5         ��Name$ ProjectComboBox��5      $
��Left=�60   $
��Auto��6K   $��3q�6Y   $��0��6d   $��Center=�6q   $	��100��6�   ��5      �� 5      .R�5      $� 5      5      �� 5       -   5        ���#2862AD$��30��5    *   $��80��66    �� CornerRadius$ 2,2,2,2��6A   	 � Cursor$
	 Hand��6�   $��	30,0,10,0q�6�   ._�5!      �� $��查询��6   $��16(�6%   ���#fff$��Center=�6E   $��Center=�6g   5"      5#      �� 5$   
   $��2��6   $��3��6   .+�5%      �� -   5        $��	ButColumn��5%   #   $��	柱状图��6   $
��Left=�64   $��
10,119,0,0q�6O   $	��Top=�6c   $��75��6{   6�   �� 5&      -   5        
 ��Name$
 ButPie��5&   #   $��	饼状图��6   $
��Left=�63   $��
10,176,0,0q�6N   $	��Top=�6b   $��75��6z   6�   �� 5'      -   5        $
 	ButSpline��5'   #   $��	折线图��6   $
��Left=�66   $��
10,238,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5(      -   5         ��Name$ Simon��5(      5)      5*      5+      