CREATE TABLE Teacher (
    TeacherID INT PRIMARY KEY,
    Name VARCHAR(50),
    Surname VARCHAR(50),
    Gender VARCHAR(10),
    Subject VARCHAR(50)
);

-- Pupil table
CREATE TABLE Pupil (
    PupilID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Gender VARCHAR(10),
    Class VARCHAR(50)
);

-- TeacherPupil linking table
CREATE TABLE TeacherPupil (
    TeacherID INT,
    PupilID INT,
    PRIMARY KEY (TeacherID, PupilID),
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
    FOREIGN KEY (PupilID) REFERENCES Pupil(PupilID)
);
INSERT INTO TeacherPupil (TeacherID, PupilID) VALUES (1, 1);
INSERT INTO TeacherPupil (TeacherID, PupilID) VALUES (1, 2);
INSERT INTO TeacherPupil (TeacherID, PupilID) VALUES (1, 1);
INSERT INTO TeacherPupil (TeacherID, PupilID) VALUES (2, 1);