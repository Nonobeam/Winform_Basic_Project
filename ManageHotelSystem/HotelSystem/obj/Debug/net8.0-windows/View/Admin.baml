   M S B A M L   `   `   `  ����K  GNguyenHuuPhucWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:NguyenHuuPhucWPF.ViewNguyenHuuPhucWPF.View  5   	   !    NguyenHuuPhucWPF.View.Admin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:NguyenHuuPhucWPF.View     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Admin��5	   	   $	��800��6   $
��1400��6$   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��350 �6   �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$	 Nav��5      $��0��6"    �� Orientation$ Vertical=�62   $��10q�6I   $��80��6U   ���	#FFE2E2E2.+�5      �� -   5        $��Report��5      $��	0,10,0,10q�6A   ���	#FFE8AE31$��60��6�   $��35��6�   ��6T   Z� 6�   �� 5      -   5         ��Name$
 Room��5      $
��Room��6#   ���	#FFE8AE31$��60��6y   $��35��6�   $��0,0,0,10q�6�   ��6K   Z� 6�   �� 5      -   5        $ Custmer��5      $��Customer��6&   ���	#FFE8AE31$��60��6�   $��35��6�   $��0,0,0,10q�6�   ��6V   Z� 6�   5      �� 5   
   -   5        $��CustomerPanel��5   1   $��1��6   $��10q�6%   .+�5      �� $��Search Customer Name��6   �� 5      $��0��6   $ 
Horizontal=�6&   $��	5,10,5,10q�6?   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��61   $��Center=�6=   $��0,0,10,0q�6X   �� 5      -   5        $��Search��5      $	��100��6E   5      �� 5!      $��Customer ID��6   �� 5"      -   5        $��CustomerIDTextBox��5"      �� 5#      $��	Full Name��6   �� 5$      -	   5        $��FullNameTextBox��5$      �� 5%      $��	Telephone��6   �� 5&      -
   5        $��TelephoneTextBox��5&      �� 5'      $��Email Address��6   �� 5(      -   5        $��EmailTextBox��5(      �� 5)      $��Birthday��6   (  "System.Windows.Controls.DatePicker  5*      -   5        $��BirthdayDatePicker��5*      �� 5+      $��Status��6   �� 5,      -   5        $��StatusComboBox��5,      .@�5-      �� $��Active��6   �� 5.      $��Deleted��6   5/      �� 50      -   5        $��AddCustomerButton��50   ,   $��Add Customer��6   $��	5,10,5,10q�6e   $	��200��6x   �� 51      -   5        $��UpdateCustomerButton��51   /   $��Update Customer��6   $��	5,10,5,10q�6n   $	��200��6�   �� 52      -   5        $��DeleteCustomerButton��52   /   $��Delete Customer��6   $��	5,10,5,10q�6n   $	��200��6�   53      �� 54   
   -   5         ��Name$ CustomerDataGrid��54      $��2��6-   $��	0,0,110,0q�6=   ���	#FFE2E2E2$	��800��6�   ��6P   Z�  �� View 55      �� 56      .P�57      �� $��	Full Name��6%   	 �� Width$		 160��6j   
 �� DisplayMemberBinding
 68   �� *CustomerFullName+6j   �� 58      $��	Telephone��6%   $		 160��6c   
 68   �� *	Telephone+6c   �� 59      $��Email Address��6%   $		 160��6j   
 6<   �� *EmailAddress+6j   �� 5:      $��Birthday��6%   $		 160��6i   
 67   �� *CustomerBirthday+6i   �� 5;      $��Status��6%   $		 160��6e   
 65   �� *CustomerStatus+6e   5<      5>      �� 5?   
   -   5        $ Logout��5?      $��2��6!   $��LOGOUT��61   $
��Left=�6B   $��18��6]   $��
858,10,0,0q�6i   $	��Top=�6}   $��57��6�   
���  ��$
��Bold"�6�   ��6�   Z� ��6�   Z� 6�   5@      5A      