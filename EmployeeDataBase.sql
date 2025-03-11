CREATE DATABASE employee;
USE employee;

CREATE TABLE employee(
		employee_id INT PRIMARY KEY,
		employee_name VARCHAR(30) NOT NULL,
		designation VARCHAR(30) NOT NULL,
		salary DECIMAL
	);

/****** Object:  Create Employee [dbo].[SPC_Employee]    Script Date: 3/11/2025 10:27:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPC_Employee](
@EmployeeId INT,
@EmployeeName VARCHAR(30),
@Designation VARCHAR(30),
@Salary DECIMAL
)
AS
BEGIN
INSERT INTO employee(employee_id,employee_name,designation,salary) VALUES(@EmployeeId,@EmployeeName,@Designation,@Salary)
END;

/****** Object:  Get Employee by ID [dbo].[SPG_Employee]    Script Date: 3/11/2025 10:28:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPG_Employee](@EmployeeId INT)
AS
BEGIN
	SELECT * FROM employee WHERE employee_id = @EmployeeId
END;

/****** Object:  Update Employee [dbo].[SPU_Employee]    Script Date: 3/11/2025 10:29:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPU_Employee](
@EmployeeID int,
@EmployeeName varchar(30),
@Designation varchar(30),
@Salary decimal
)
AS
BEGIN
	UPDATE [dbo].[employee]
	SET employee_name = @EmployeeName,
		designation = @Designation,
		salary = @Salary
	where employee_id = @EmployeeID
end

/****** Object:  Delete Employee [dbo].[SPD_Employee]    Script Date: 3/11/2025 10:13:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPD_Employee] @EmployeeId INT
AS
BEGIN
DELETE FROM [dbo].[employee] WHERE employee_id=@EmployeeId
END;
