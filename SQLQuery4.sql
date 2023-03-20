CREATE TABLE Teacher (
  id INT PRIMARY KEY,
  name VARCHAR(50),
  surname VARCHAR(50),
  gender VARCHAR(10),
  subject VARCHAR(50)
);
CREATE TABLE Pupil (
  id INT PRIMARY KEY,
  first_name VARCHAR(50),
  last_name VARCHAR(50),
  gender VARCHAR(10),
  class VARCHAR(20)
);

CREATE TABLE Teacher_Pupil (
  teacher_id INT,
  pupil_id INT,
  PRIMARY KEY (teacher_id, pupil_id),
  FOREIGN KEY (teacher_id) REFERENCES Teacher(id),
  FOREIGN KEY (pupil_id) REFERENCES Pupil(id)
);
SELECT DISTINCT t.name, t.surname
FROM Teacher t
INNER JOIN Teacher_Pupil tp ON t.id = tp.teacher_id
INNER JOIN Pupil p ON tp.pupil_id = p.id
WHERE p.first_name = 'Giorgi';