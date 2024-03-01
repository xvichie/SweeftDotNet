SELECT t.*
FROM Teachers t
JOIN TeacherPupils tp ON t.Id = tp.TeacherId
JOIN Pupils p ON tp.PupilId = p.Id
WHERE p.FirstName = 'Giorgi';
