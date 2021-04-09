CREATE DATABASE FitDeck;

USE FitDeck;

CREATE TABLE [User] (
	UserId INT IDENTITY(1, 1) NOT NULL,
	UserName VARCHAR(50) NOT NULL,
	[Password] NVARCHAR(60) NOT NULL,
	EmailAddress VARCHAR(50) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	BirthDate DATE NOT NULL,
	Height DECIMAL NOT NULL,
	[Weight] DECIMAL NOT NULL,
	PRIMARY KEY(UserID)
);
GO

CREATE TABLE [Exercise](
	ExerciseId INT IDENTITY(1,1) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	MuscleGroup VARCHAR(50) NOT NULL,
	WorkoutType VARCHAR(50) NOT NULL,
	[Sets] INT NOT NULL,
	Reps INT NOT NULL,
	PRIMARY KEY(ExerciseId)
	
);
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
	FOREIGN KEY(ExerciseId) REFERENCES Exercise(ExerciseId)
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
	Title VARCHAR(50) NOT NULL,
	[DayOfWeek] VARCHAR(50) NOT NULL,
	PRIMARY KEY(WorkoutId)
)
GO

CREATE TABLE [UserCreatedWorkouts_Exercises](
	WorkoutId INT NOT NULL,
	ExerciseId INT NOT NULL,
	FOREIGN KEY(WorkoutId) REFERENCES UserCreatedWorkouts(WorkoutId),
	FOREIGN KEY(ExerciseId) REFERENCES Exercise(ExerciseId)
)
GO

CREATE TABLE [UserCreatedRoutines](
	RoutineId INT IDENTITY(1,1) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	RestDay VARCHAR(50) NOT NULL,
	PRIMARY KEY(RoutineId)
)
GO

CREATE TABLE [UserCreatedRoutines_Workouts](
	RoutineId INT NOT NULL,
	WorkoutId INT NOT NULL,
	FOREIGN KEY(RoutineId) REFERENCES UserCreatedRoutines(RoutineId),
	FOREIGN KEY(WorkoutId) REFERENCES UserCreatedWorkouts(WorkoutId)
)
GO

CREATE TABLE [SavedWorkouts](
	UserId INT NOT NULL,
	PreDeterminedRoutineId INT NULL,
	PreDeterminedWorkoutId INT Null,
	UserCreatedRoutineId INT NULL,
	UserCreatedWorkoutId INT NULL,
	FOREIGN KEY(PreDeterminedRoutineId) REFERENCES PreDeterminedRoutines(RoutineId),
	FOREIGN KEY(PreDeterminedWorkoutId) REFERENCES PreDeterminedWorkouts(WorkoutId),
	FOREIGN KEY(UserCreatedRoutineId) REFERENCES UserCreatedRoutines(RoutineId),
	FOREIGN KEY(UserCreatedWorkoutId) REFERENCES UserCreatedWorkouts(WorkoutId)
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
--Add predetermined Exercise to the Exercise Table
INSERT INTO Exercise(Title, MuscleGroup, WorkoutType, [Sets], Reps)
VALUES('Bench Press', 'Chest', 'Strength', 3, 6);

INSERT INTO Exercise(Title, MuscleGroup, WorkoutType, [Sets], Reps)
VALUES('Incline Barbell Bench', 'Chest', 'Strength', 3, 6);

INSERT INTO Exercise(Title, MuscleGroup, WorkoutType, [Sets], Reps)
VALUES('Incline Dumbbell Bench', 'Chest', 'Strength', 3, 6);

INSERT INTO Exercise(Title, MuscleGroup, WorkoutType, [Sets], Reps)
VALUES('Dumbbell Flies', 'Chest', 'Strength', 3, 6);
INSERT INTO Exercise(Title, MuscleGroup, WorkoutType, [Sets], Reps)
VALUES('Barbell Deadlift', 'Back', 'Strength', 3, 6);
INSERT INTO Exercise(Title, MuscleGroup, WorkoutType, [Sets], Reps)
VALUES('Bent Over Row', 'Back', 'Strength', 3, 6);
INSERT INTO Exercise(Title, MuscleGroup, WorkoutType, [Sets], Reps)
VALUES('Lat Pulldown (Close Grip)', 'Back', 'Strength', 3, 6);
INSERT INTO Exercise(Title, MuscleGroup, WorkoutType, [Sets], Reps)
VALUES('Barbell Deadlift', 'Back', 'Strength', 3, 6);
--Create a new Workout
INSERT INTO PreDeterminedWorkouts(Title, [DayOfWeek]) VALUES ('Shane Chest Day', 'Monday');

--Add Exercises to a Workout
INSERT INTO PreDetermindedWorkout_Exercises(WorkoutId, ExerciseId) VALUES (1, 1);
INSERT INTO PreDetermindedWorkout_Exercises(WorkoutId, ExerciseId) VALUES (1, 2);
INSERT INTO PreDetermindedWorkout_Exercises(WorkoutId, ExerciseId) VALUES (1, 3);
INSERT INTO PreDetermindedWorkout_Exercises(WorkoutId, ExerciseId) VALUES (1, 4);

--Stored Procedures
CREATE PROCEDURE GetExerciseByMuscleGroup
	@MuscleGroup VARCHAR(50)
AS
	SELECT
		*
	FROM [Exercise] t1
	Where t1.MuscleGroup = @MuscleGroup
GO
CREATE PROCEDURE GetAllExercisesOfAPreDeterminedWorkout
	@WorkoutId INT
AS
	SELECT
		ex.Title,
		ex.MuscleGroup,
		ex.WorkoutType,
		ex.[Sets],
		ex.Reps
	FROM PreDetermindedWorkout_Exercises pdwE
	INNER JOIN PreDeterminedWorkouts pdw ON pdwE.WorkoutId = @WorkoutId
	INNER JOIN Exercise ex ON pdwE.ExerciseId = ex.ExerciseId
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

CREATE PROCEDURE AddExercise
	@Exercise ExerciseType READONLY
AS
	INSERT INTO
		[dbo].[Exercise](
			[Title],
			[MuscleGroup],
			[WorkoutType],
			[Sets],
			[Reps]
		)
	SELECT
		[Title],
		[MuscleGroup],
		[WorkoutType],
		[Sets],
		[Reps]
	FROM
		@Exercise
	
	SELECT CAST(SCOPE_IDENTITY() AS INT);
GO