   M S B A M L   `   `   `  ����I  EWpfAppDuikstek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfAppDuikstekWpfAppDuikstek  5      %    WpfAppDuikstek.PageBewerkVissen   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfAppDuikstek     5        N� Title$  PageBewerkVissen��5	       N� 
Background
 �����.��5      � $��20,10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   .+�5      	� -   5         	�Name$ newFish��5      $��
Nieuwe Vis��6+   $��5q�6@   6K   	� 5      -   5        $ existingFish��5      $��5q�60   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Bestaande Vis��6    $��0,0,10,0q�65   �� 5      -   5         ��Name$ 
selectFish��5      $	��100��63   {�.  6T   5      5       5!      �� 5#   
   $��1��6   .+�5$      �� $��Naam: ��6   $��15(�6&   $
��Bold"�64   �� 5%      -   5         ��Name$ tbName��5%      $��30��6&   $��20(�62   {�.  6@   5&      �� 5(   
   $��2��6   .+�5)      �� $��Beschrijving: ��6   $��15(�6.   $
��Bold"�6<   �� 5*      -   5        $ tbDescription��5*      $	��100��6-   {�.  6:   5+      �� 5-   
   $��3��6   .+�5.      �� $��Type Water: ��6   $��15(�6,   $
��Bold"�6:   � 5/      .+�50      	� -   5        $ 	saltwater��50      $��
Zout Water��61   $��5q�6F   {�.  6Q   	� 51      -   5        $ 
freshwater��51      $��
Zoet Water��62   $��5q�6G   {�.  6R   	� 52      -   5        $ other��52      $��Anders��6-   $��5q�6>   {�.  $��Italic$�6[   53      54      �� 56   
   $��4��6   .+�57      �� $��Kleuren* : ��6   $��15(�6+   $
��Bold"�69   �� 58      -	   5        $ tbColors��58      $��30��6(   {�.  65   59      �� 5;   
   $��5��6   .+�5<      �� $$��Gemmidelde grootte (in cm)* : ��6   $��15(�6>   $
��Bold"�6L   �� 5=      -
   5        $ 	tbAvgSize��5=      $��30��6)   {�.  6H   5>      �� 5@   
   $��6��6   .+�5A      �� $��Laats Bijgewerkt: ��6   $��15(�62   $
��Bold"�6@   (  "System.Windows.Controls.DatePicker  5B      -   5          Name$ lastUpdated��5B      {�.  6.   5C      � 5E   
   $��7��6   $
��0,10q�6!   .+�5F      �� -   5         ��Name$ 
btnAddFish��5F      $��Voeg Toe��6)   $
��Left=�6<   $	��0,5q�6W   $
��10,0q�6d   {�.  6�   �� 5G      -   5        $ btnUpdateFish��5G      $��Update��6,   $
��Left=�6=   $	��0,5q�6X   $
��10,0q�6e   $y�	Collapsed=�6�   {�.  6�   �� 5H      -   5        $ btnRemoveFish��5H      $��	Verwijder��6,   $
��Left=�6@   $
��10,5q�6[   $
��10,0q�6i   $y�	Collapsed=�6�   {�.  6�   5I      �� 5K   
   $��8��6   $��* niet verplichte velden��6!   5M      5N      