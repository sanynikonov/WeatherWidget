   M S B A M L   `   `   `  ����H  DWeatherWidget, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WeatherWidgetWeatherWidget  5   	       WeatherWidget.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WeatherWidget     5   	   -   5        $��Window��5   	   $	��130��6   $	��250��6$     � AllowsTransparency  .  � WindowStyle$
 None=�5	   	    � ShowInTaskbar .  
������� � 	Resources 5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � ContextMenu 5   
   �� 5      -   5        $��ContextMenu��5       � DataContext 6-   �� *	ViewModel+.@�5      m� -   5        $��MenuItemClose��5      $��Close��60   6?   m� 5      $��Golosui za Poroshenka��6   5       � ColumnDefinitions 5   
   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��0.25* �6   6-   .+�5   
   �� $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��2,2,2,2q�6   
�������$��0q�69   	 � ToolTip$	 OpenWeather.org��5   <   ��6   �� *OpenWeatherCommand+.��5       �� $��Image/openweather.png��6   69   5!      �� 5"      $��2,2,2,2q�6   
�������$��0q�69   $	 	Apixu.com��5#   6   ��6   �� *ApixuCommand+.��5$      �� $��Image/apixu.png��6   64   5%      �� 5&      $��2,2,2,2q�6   
�������$��A��69   $��21��6E   $��0q�6P   $	 Average.our��6d   $��Center=�5'      $��13(�62   ��6@   �� *AverageWeatherCommand+5(      �� 5+   
   $��2��6   $��1��6%   $ 
Horizontal=�62   $��Right=�6K    5,      �� *SelectedWeatherDay+.+�5-      �� $��Image/RainFalse1.png��6   y�62   �� 
 �� Path$
 Rainy� �� 	Converter# [  6�   �� 5.      $��Image/CoatFalse1.png��6   y�62   �� $
 Snowy�# [  6�   5/      � 50   
   $��2��6   $��1��6#   $��0��63    6@   �� *SelectedWeatherDay+ �� UpdateSourceTrigger$ PropertyChanged=� 51      �� 52      $��* �6#   6/   �� 53      $
��0.5* �6#   62   �� 54      $��* �6#   6/    56      �� 57      $��* �6    6-   �� 58      $��* �6    6-   �� 59      $��* �6    6-   �� 5:      $��* �6    6-   �� 5;      $��* �6    6-   .+�5=      �� $��0��6   $��3��6&   $ 
Horizontal=�6:   $��Center=�6S   .+�5>      �� $��<��6   $��
0, 0, 5, 0q�6(   $��20��6<   $��20��6G   $��0q�6S   ��5?      ��  �� ElementName$ Window��$
 
Background�6V   �� 5@      $��3��6   $��0��60   $��0��6@   $��Center=�6M   $��Center=�5A      $��16(�63   $
��Bold"�6A   ��6S   �� *Date+$ PropertyChanged=�6�   �� 5B      $��>��6   $��
5, 0, 0, 0q�6(   $��20��6<   $��20��6G   $��0q�6S   ��5C      �� $ Window��$
 
Background�6V   5D      �� 5E      $��1��6   $��0��6%   $��Center=�65   $��Center=�6R   	Temp, °C6w   �� 5F      $��2��6   $��0��6%   $��Center=�65   $��Center=�6R   Pressure, mm6{   �� 5G      $��3��6   $��0��6%   $��Center=�65   $��Center=�6R   
Wind, °6v   �� 5H      $��4��6   $��0��6%   $��Center=�65   $��Center=�6R   	Wind, m/s6x   �� 5J      $��1��6   $��1��6%   $��Center=�65   $��Center=�6R   ��5K      �� *Temperature+$ PropertyChanged=�6\   �� 5L      $��2��6   $��1��6%   $��Center=�65   $��Center=�6R   ��5M      �� *
Pressure+$ PropertyChanged=�6Y   �� 5N      $��3��6   $��1��6%   $��Center=�65   $��Center=�6R   ��5O      �� *WindDirection+$ PropertyChanged=�6^   �� 5P      $��4��6   $��1��6%   $��Center=�65   $��Center=�6R   ��5Q      �� *SpeedOfWind+$ PropertyChanged=�6\   �� 5R      $��3��6   $��4��6$   $��1��65   ��6B   �� *Sky+6[   5S      5V      5W      