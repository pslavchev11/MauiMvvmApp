   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UI.ComponentsUI.Components  5          UI.Components.LoggedData   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:UI.Components     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $
��logs��5         AutoGenerateColumns$ False��67   ��6   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Time+5      �� 5   
   -   5         ��Name$ hidden��5      $
��Info��6"   $y�	Collapsed=�6.   $��1��6E   6T   5      5      