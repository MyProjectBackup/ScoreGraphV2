   M S B A M L   `   `   `  ���� G  CScoreGraphV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ScoreGraphV2ScoreGraphV2      ScoreGraphV2.ScoreGraph   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ScoreGraphV2       � Title$  阶段曲线图��$	��510��$	��800�� � Icon$ Account.theme-light.ico�� � 
ResizeMode$ CanMinimize=�.���  � ColumnDefinitions �� $
��118* ��� $
��377* ��� $
��297* � � RowDefinitions �� $��30 ��� $��30 ��� $��* �.+��� $��0��$*��$近十次单科目训练成绩曲线��$��Center=�$��18(�$��Bottom=�$��2��$��169.796,0,288,0q�$��1����  �� Orientation$ 
Horizontal=�$��1��$��Center=�$��2��$��51.796,0,170,0q�$��1��.+��� $��姓名��$��Center=�$��16(��� -    ��Name$ 
Users_Name��$	��100��$��20��$��Center=�$��Right=�$��0,0,10,0q��� $��训练科目��$��Center=�$��16(��� -    ��Name$ ProjectComboBox��$
��Left=�$
��Auto��$��3q�$��0��$��Center=�$	��100������ .R�$� �� -   ���#2862AD$��30��$��80�� �� CornerRadius$ 2,2,2,2��	 � Cursor$
	 Hand��$��	30,0,10,0q�._��� $��查询��$��16(����#fff$��Center=�$��Center=��� $��2��$��3��.+��� -   $��	ButColumn��$��	柱状图��$
��Left=�$��
10,119,0,0q�$	��Top=�$��75���� -   
 ��Name$
 ButPie��$��	饼状图��$
��Left=�$��
10,176,0,0q�$	��Top=�$��75���� -   $
 	ButSpline��$��	折线图��$
��Left=�$��
10,238,0,0q�$	��Top=�$��75���� -    ��Name$ Simon��