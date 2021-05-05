CREATE DATABASE FitDeck;

USE FitDeck;

CREATE TABLE [User] (
	UserId INT IDENTITY(1, 1) NOT NULL,
	UserName VARCHAR(50) NOT NULL,
	NormalizedUserName VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	NormalizedEmail VARCHAR(50) NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	HeightInches INT NOT NULL,
	[Weight] DECIMAL NOT NULL,
	PasswordHash NVARCHAR(MAX) NOT NULL,
	PRIMARY KEY(UserID)
);
GO

CREATE TYPE [dbo].[AccountType] AS TABLE(
	[Username] VARCHAR(20) NOT NULL,
	[NormalizedUsername] VARCHAR(20) NOT NULL,
	[Email] VARCHAR(30) NOT NULL,
	[NormalizedEmail] VARCHAR(30) NOT NULL,
	[Fullname] VARCHAR(30) NOT NULL,
	[Age] INT NOT NULL,
	[HeightInches] INT NOT NULL,
	[Weight] DECIMAL NOT NULL,
	[PasswordHash] NVARCHAR(max) NOT NULL
)
GO
CREATE TYPE WorkoutType AS TABLE(
	[UserId] INT NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[DayOfWeek] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [PreDeterminedWorkouts](
	WorkoutId INT IDENTITY(1,1) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	[DayOfWeek] VARCHAR(50) NOT NULL,
	PRIMARY KEY(WorkoutId)
)
GO

CREATE TABLE [PreDetermindedWorkout_Exercises](
	WorkoutId Int NOT NULL,
	ExerciseId INT NOT NULL,
	FOREIGN KEY(WorkoutId) REFERENCES PreDeterminedWorkouts(WorkoutId),
)
GO

CREATE TABLE [PreDeterminedRoutines](
	RoutineId INT IDENTITY(1,1) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	RestDay VARCHAR(50) NOT NULL,
	PRIMARY KEY(RoutineId)
)
GO

CREATE TABLE [PreDetermindeRoutines_Workouts](
	RoutineId INT NOT NULL,
	WorkoutId INT NOT NULL,
	FOREIGN KEY(RoutineId) REFERENCES PreDeterminedRoutines(RoutineId),
	FOREIGN KEY(WorkoutId) REFERENCES PreDeterminedWorkouts(WorkoutId)
)
GO

CREATE TABLE [UserCreatedWorkouts](
	WorkoutId INT IDENTITY(1, 1) NOT NULL,
	UserId INT NOT NULL,
	Title VARCHAR(50) NOT NULL,
	[DayOfWeek] VARCHAR(50) NOT NULL,
	PRIMARY KEY(WorkoutId),
	FOREIGN KEY (UserID) REFERENCES [User](UserId)
)
GO

CREATE TABLE [UserCreatedWorkouts_Exercises](
	WorkoutId INT NOT NULL,
	ExerciseId INT NOT NULL,
	FOREIGN KEY(WorkoutId) REFERENCES UserCreatedWorkouts(WorkoutId)
)
GO

CREATE TABLE [UserCreatedRoutines](
	RoutineId INT IDENTITY(1,1) NOT NULL,
	UserId INT NOT NULL,
	Title VARCHAR(50) NOT NULL,
	RestDay VARCHAR(50) NOT NULL,
	PRIMARY KEY(RoutineId),
	FOREIGN KEY (UserID) REFERENCES [User](UserId)
)
GO

CREATE TABLE [UserCreatedRoutines_Workouts](
	RoutineId INT NOT NULL,
	WorkoutId INT NOT NULL,
	FOREIGN KEY(RoutineId) REFERENCES UserCreatedRoutines(RoutineId),
	FOREIGN KEY(WorkoutId) REFERENCES UserCreatedWorkouts(WorkoutId)
)
GO



CREATE TABLE [DailyStats](
	UserId INT NOT NULL,
	[Date] DATE NOT NULL,
	WorkoutTime DECIMAL NOT NULL,
	CaloriesBurned DECIMAL NOT NULL
	FOREIGN KEY(UserId) REFERENCES [User](UserId)
)
GO

CREATE TABLE [WeeklyStats](
	UserId INT NOT NULL,
	[WeekNum] INT NOT NULL,
	WorkoutTime DECIMAL NOT NULL,
	CaloriesBurned DECIMAL NOT NULL
	FOREIGN KEY(UserId) REFERENCES [User](UserId)
)
GO

--Stored Procedures
CREATE PROCEDURE [AddUser]
	@Account AccountType READONLY
AS
INSERT INTO [dbo].[User]
           ([UserName]
           ,[NormalizedUserName]
           ,[Email]
           ,[NormalizedEmail]
           ,[FullName]
           ,[Age]
           ,[HeightInches]
           ,[Weight]
           ,[PasswordHash])
     SELECT
           [UserName]
           ,[NormalizedUserName]
           ,[Email]
           ,[NormalizedEmail]
           ,[FullName]
           ,[Age]
           ,[HeightInches]
           ,[Weight]
           ,[PasswordHash]
	FROM
		@Account
	SELECT CAST(SCOPE_IDENTITY() AS INT);
GO

CREATE PROCEDURE GetUserByUserName
	@UserName VARCHAR(50)
AS
	SELECT
		*
	FROM [dbo].[User] appUser
	WHERE appUser.Username = @UserName
GO

CREATE PROCEDURE GetUserByUserId
	@UserId INT
AS
	SELECT
		*
	FROM [dbo].[User] appUser
	WHERE appUser.UserId = @UserId
GO

CREATE PROCEDURE AddUser
	@Account AccountType READONLY
AS
	INSERT INTO
		[dbo].[User]
		(
			[UserName],
			[Password],
			[EmailAddress],
			[FirstName],
			[LastName],
			[BirthDate],
			[Height],
			[Weight]
		)
		SELECT
			[UserName],
			[PasswordHash],
			[Email],
			[FirstName],
			[LastName],
			[BirthDate],
			[Height],
			[Weight]
		FROM
			@Account;
		SELECT CAST(SCOPE_IDENTITY() AS INT);
GO
CREATE PROCEDURE AddWorkout
	@Workout WorkoutType READONLY
AS
INSERT INTO [dbo].[UserCreatedWorkouts]
			(
				[UserId],
				[Title],
				[DayOfWeek]
			)
		SELECT
			[UserId],
			[Title],
			[DayOfWeek]
		FROM
			@Workout
		SELECT CAST(SCOPE_IDENTITY() AS INT);