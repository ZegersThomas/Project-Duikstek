   M S B A M L   `   `   `  ����I  EWpfAppDuikstek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfAppDuikstekWpfAppDuikstek  5   	       WpfAppDuikstek.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfAppDuikstek     5   	     � Title$"  Duikstek en Vissen aanpassen��5   	   $	��600��6.   $
��1000��6;   $	��300��6H   $	��500��6X   ���#0688EA.��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��155 �6   �� 5      $��* �6   .+�5   
   �� .+�5      �� -   5         ��Name$ btnBewerkDuiksteks��5      $��Bewerk Duiksteks��5      $��
15,15,15,0q�5      $
��15,5q�5      6$   �� 5      -   5        $ btnBewerkVissen��5      $��Bewerk vissen��5      $��
15,15,15,0q�5      $
��15,5q�5      6$   5      �� 5   
   $��assets/duikIcon.jpg��6   $��Bottom=�6-   $
��0,20q�6H   �� 5   
   	 �� X1$ 0��6   	 �� Y1$ 0��6   	 �� X2$ 0��6   
�������$��2��5    "   $
��Left=�5!      $��	154,0,0,0q�6*   	 �� Y2 5   $   �� *ActualHeight+ �� RelativeSource �� 	 �� AncestorType$
	 GridL�5!   *   �� 5#   
   $��1��6   $
��Auto=�6'   $��Disabled=�6J   .��5$       � -   5        
  �Name$
 	mainFrame��5$        � NavigationUIVisibility$ Hidden=�5%      5&      5)      5*      