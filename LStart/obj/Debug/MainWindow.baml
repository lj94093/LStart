   M S B A M L   `   `   `  ����A  =LStart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LStartLStart  5   	   1clr-namespace:LStart.ControlsLStart.Controls  5   	   clr-namespace:LStartLStart  5   	       LStart.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:LStart     5   	   2controlsclr-namespace:LStart.Controls     5   	   'lStartclr-namespace:LStart     5   	     � Title$  LStart��5
   	    � AllowsTransparency .  � WindowStartupLocation$ Manual=�5   #    J� 	AllowDrop .  � WindowStyle$
 None=�5   	   $	��200��6    � Icon$# Resources/img/application.png��6+   $��1q�5   	   ��5
      ��  �� Path$ height� �� Mode$ TwoWay=���6C   �� $ width�$ TwoWay=�
 � Top 5   	   �� $	 top�$ TwoWay=�	 � Left	 6.   �� $
 left�$ TwoWay=�
 � Topmost
 5      �� $ 	isTopMost�$ TwoWay=� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      
BlurRadius$ 25Q�6      Color$ 	#FF858484��6+      	Direction$ 90Q�6=      ShadowDepth$ 3Q�6L    � 	Resources 5          LStart.GridLengthConverter   GridLengthConverter��%   &	          5   
   6%   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��80��6   $	��300��6�   ��6   �� $ leftListWidth� �� 	Converter# [  $ TwoWay=�6�   �� 5      $
��148* �6   $	��100��6,    � RowDefinitions 5   
   �� 5      $��32 �6   �� 5      $��* �6   .+�5   
   ]� -   5         ]�Name$ 
TitlePanel��5      $��32��6(   ��.  $��0��6J     
Background#��[ 6W   $��2��6�   .+�5      �� -   5        $��CloseButton��5      $��32��6(   $	��Top=�64   $��32��6L   $��Right=�6W   $��0q�6n   ��5       �� 5!       �� ImageSource$ Resources/img/close.png��6!    j� Stretch$
 Fill=�6G   5#      �� 5$      -   5        $��
MoreButton��5$      $��32��6'   $	��Top=�63   $��32��6K   $��Right=�6V   $��0q�6m   ��5%      �� 5&      $ Resources/img/more.png��6!   $
 Fill=�6F   5(      �� 5)      -   5        $��SearchButton��5)      $��32��6)   $	��Top=�65   $��32��6M   $��Right=�6X   $��0q�6o   ��5*      �� 5+      $ Resources/img/search.png��6!   $
 Fill=�6H   5.      �� 5/      -   5        $��	SearchBox��5/      $��25��6'    �� TextWrapping$
 Wrap=�63   $��Center=�6G   $	��300��50      $��Center=�6"   $y�	Collapsed=�6D   $��50,0,0,0q�51      .��52   9   53      � 54      -   5        $��Popup��54      $	��300��6!   .��55         LStart.Controls.PopupList  -   5          Name$ 	PopupList��55   %   6:   56      58         LStart.Controls.LeftList  59   
   -   5          Name$ LeftList��59      $��1��6.   $��0��6;   6M      LStart.Controls.RightList  5:   
   -	   5          Name$ 	RightList��5:      $��1��60   $��1��6@   �� 5;   
   $��0��6   $��1��6'   $��1��64    �� ResizeDirection$ Columns=�6>   #��[ 6X   5<      5=      