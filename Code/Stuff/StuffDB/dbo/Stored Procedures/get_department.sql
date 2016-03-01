CREATE PROCEDURE [dbo].[get_department] @id INT = NULL, @get_emp_count BIT = 0, @has_ad_account bit = NULL, @employee_sid varchar(46) = NULL
AS
    BEGIN
        SET NOCOUNT ON;
		DECLARE @id_employee int

		SELECT @id_employee = id FROM employees_view WHERE ad_sid = @employee_sid

        SELECT  d.id ,
                d.name ,
                id_parent ,
                parent ,
                id_chief ,
                chief,
				em.ad_sid AS chief_sid,
				CASE WHEN @get_emp_count = 1 THEN 
				(SELECT COUNT(1) FROM employees_view e WHERE e.id_department = d.id and (@has_ad_account is null or (@has_ad_account is not null and e.has_ad_account = @has_ad_account)))
				 ELSE NULL END AS emp_count,
				 hidden
        FROM    departments_view d
		LEFT JOIN employees_view em ON d.id_chief = em.id
        WHERE   ( @id IS NULL
                      OR ( @id IS NOT NULL
                           AND @id > 0
                           AND d.id = @id
                         )
                    )
					AND (@employee_sid IS NULL OR @employee_sid = '' OR (@employee_sid IS NOT NULL AND @employee_sid != '' AND (d.id_chief = @id_employee OR EXISTS(SELECT 1 FROM employees_view emp WHERE emp.id_department = d.id AND emp.ad_sid = @employee_sid))))
					order by d.name
    END