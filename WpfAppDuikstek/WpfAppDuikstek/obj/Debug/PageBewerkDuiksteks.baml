   M S B A M L   `   `   `  ����I  EWpfAppDuikstek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfAppDuikstekWpfAppDuikstek  5      (    "WpfAppDuikstek.PageBewerkDuiksteks   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfAppDuikstek     5        N� Title$  PageBewerkDuiksteks��5	       N� 
Background
 �����.��5      � $��20,10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   .+�5      	� -   5         	�Name$ newDiveLocation��5      $��Nieuwe Duikstek��63   $��5q�6M   6X   	� 5      -   5        $ existingDiveLocation��5      $��5q�68   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Bestaande Duikstek��6    $��0,0,10,0q�6:   �� 5      -   5         ��Name$ selectDiveLocation��5      $	��100��6;   {�.  6\   5      5      5      �� 5!   
   $��1��6   .+�5"      �� $��Naam: ��6   $��15(�6&   $
��Bold"�64   �� 5#      -   5         ��Name$ tbName��5#      $��30��6&   $��20(�62   {�.  6@   5$      �� 5&   
   $��2��6   .+�5'      �� $��Beschrijving: ��6   $��15(�6.   $
��Bold"�6<   �� 5(      -   5        $ tbDescription��5(      $	��100��6-   {�.  6:   5)      �� 5+   
   $��3��6   .+�5,      �� $��Vissen: ��6   $��15(�6(   $
��Bold"�66   � 5-      .+�5.      �� -   5        $ 	cmbFishes��5.      $
��Left=�6.   $	��150��6I   $	��0,5q�6X   {�.  6e   �� 5/      -   5         ��Name$ 
btnAddFish��5/      $��Voeg toe��6-   $
��Left=�6@   $
��10,5q�6[   $
��10,0q�6i   {�.  6�   50      �� 51      -   5         ��Name$ lbFishes��51      $��50��6(   � 52      .+�53      �� -	   5        $ btnRemoveFish��53      $��	verwijder��60   $
��Left=�6D   $	��0,5q�6_   $
��10,0q�6l   {�.  6�   �� 54      -
   5        $ btnRemoveAllFish��54      $��verwijder alle vissen��63   $
��Left=�6S   $
��10,5q�6n   $
��10,0q�6|   {�.  6�   55      57      �� 59   
   $��4��6   .+�5:      �� $��Type Water: ��6   $��15(�6,   $
��Bold"�6:   � 5;      .+�5<      	� -   5        $ 	saltwater��5<      $��
Zout Water��61   $��5q�6F   {�.  6Q   	� 5=      -   5        $ 
freshwater��5=      $��
Zoet Water��62   $��5q�6G   {�.  6R   	� 5>      -   5        $ other��5>      $��Anders��6-   $��5q�6>   {�.  $��Italic$�6[   5?      5@      �� 5B   
   $��5��6   .+�5C      �� $��Laats Bijgewerkt: ��6   $��15(�62   $
��Bold"�6@   (  "System.Windows.Controls.DatePicker  5D      -   5        	  Name$	 lastUpdated��5D      {�.  6.   5E      � 5G   
   $��6��6   $
��0,10q�6!   .+�5H      �� -   5        $ btnAddDiveLocation��5H      $��Voeg Toe��61   $
��Left=�6D   $	��0,5q�6_   $
��10,0q�6l   {�.  6�   �� 5I      -   5        $ btnUpdateDiveLocation��5I      $��Update��64   $
��Left=�6E   $	��0,5q�6`   $
��10,0q�6m   $y�	Collapsed=�6�   {�.  6�   �� 5J      -   5        $ btnRemoveDiveLocation��5J      $��	Verwijder��64   $
��Left=�6H   $
��10,5q�6c   $
��10,0q�6q   $y�	Collapsed=�6�   {�.  6�   5K      5L      5M      