   M S B A M L   `   `   `  ���� G  CScoreGraphV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ScoreGraphV2ScoreGraphV2  (    "ScoreGraphV2.ChineseCharacterInput   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ScoreGraphV2       � Title$'  !汉字输入近十次训练数据��$	��300��$	��650�� � Icon$ Account.theme-light.ico�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ 	dataGrid2��
������    AutoGenerateColumns .  ����  �� 
TargetType"  .���  �� Property �@ HeadersVisibility �� Value$ Column=���   �@ HorizontalGridLinesBrush �� 	 �� Color$
	 #333��
 �� Opacity$	
 0.2Q���  �@ VerticalGridLinesBrush �� $
	 #333��$	
 0.2Q�   ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � �� �#E1F1FF��  � �� �#000��  � ��$ Center=���  � �� �� $
	 #333��$	
 0.2Q�   RowStyle �� )  #System.Windows.Controls.DataGridRow"  .���  � ��$ 0q� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �� $	 #E1F1FF��$
 1Q�P�  �@ 
IsSelected . . ���  � ��
 �  ��   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ 0q� P�  �@ 
IsSelected . . ���  � �� �� $	 AntiqueWhite��$	
 0.9Q���  � ��
 �  ��   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 姓名��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40    CellTemplate �� .R��� $��Center=�$��Center=�.+��� ���� *Name+  $ 速度(字/分)��$ 70  �� .R��� $��Center=�$��Center=�.+��� ���� *CountPerMinutes+  $ 正确率（%）��$ 70  �� .R��� $��Center=�$��Center=�.+��� ���� *CorrectPercentage+  $ 完成率（%）��$ 70  �� .R��� $��Center=�$��Center=�.+��� ���� *FinishedPercentage+  $ 考核用时（秒）��$	 100  �� .R��� $��Center=�$��Center=�.+��� ���� *
Interval+  $ 开始时间��$	 140  �� .R��� $��Center=�$��Center=�.+��� ���� *	StartAt+  $ 提交时间��$	 140  �� .R��� $��Center=�$��Center=�.+��� ���� *
LastUpdate+