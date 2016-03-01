




















CREATE VIEW [dbo].[recruit_selections_report]
AS
SELECT        s.*
, c.display_name AS candidate_display_name, 
                         c.birth_date AS candidate_birth_date, c.phone AS candidate_phone, c.email AS candidate_email, c.male AS candidate_male, st.name AS state_name, e_ch.display_name AS state_changer_name,
	st_next.id AS next_state_id, st_next.name AS next_state_name, st.show_next_state_btn, st.is_active AS state_is_active, st_next.btn_name AS next_state_btn_name,
	st.is_accept AS state_is_accept,
	c.surname AS candidate_surname, c.name AS candidate_name, c.patronymic AS candidate_patronymic,
	v.position_name AS vacancy_position_name, v.department_name AS vacancy_department_name, v.candidate_total_count AS vacancy_candidate_total_count
	, v.candidate_cancel_count AS vacancy_candidate_cancel_count,
	v.personal_manager_name AS vacancy_personal_manager_name, v.dattim1 AS vacancy_date_create, v.state_name AS vacancy_state_name,
	v.state_change_date AS vacancy_state_change_date, v.state_changer_name AS vacancy_state_changer_name, v.cause_name AS vacancy_cause_name,
	v.creator_name AS vacancy_creator_name, /*c.file_name AS candidate_file_name, c.file_sid AS candidate_file_sid,*/
	c.came_type_name as candidate_came_type_name, ct.name as came_type_name, v.id_city as vacancy_id_city, v.city_name as vacancy_city_name,
	c.came_resource_name as candidate_came_resource_name, v.id_branch_office as vacancy_id_branch_office, v.branch_office_name as branch_office_name
FROM            dbo.recruit_selections AS s INNER JOIN
                         dbo.recruit_candidates_view AS c WITH (NOLOCK) ON c.id = s.id_candidate 
						 left join recruit_candidate_came_types ct on s.id_came_type = ct.id
						 INNER JOIN dbo.recruit_vacancies_view v ON v.id=s.id_vacancy INNER JOIN
                         dbo.recruit_selection_states AS st ON s.id_state = st.id LEFT OUTER JOIN
                         dbo.employees AS e_ch WITH (NOLOCK) ON e_ch.ad_sid = s.state_changer_sid
						 LEFT JOIN dbo.recruit_selection_states AS st_next ON st_next.id = (SELECT TOP 1 id FROM dbo.recruit_selection_states sss WHERE enabled=1 AND sss.order_num > st.order_num)
WHERE        (s.enabled = 1)























GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 136
               Right = 465
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "st"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e_ch"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 268
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'recruit_selections_report';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'recruit_selections_report';

