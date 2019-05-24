using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApp.OtherClasses.Final
{
    /// <summary>
    /// Класс отвечающий за взаимодействие данных с файлом
    /// </summary>
    [Serializable]
    public class DataSource
    {
        //Расположение файлов записи данных
        private static string _dataSourcePath;
        private static string _userSavePath;
        //Название файлов с данными
        private readonly string _dataSchoolRooms = $"{_dataSourcePath}\\SchoolRooms.dat";
        private readonly string _dataUniversityRooms = $"{_dataSourcePath}\\UniversityRooms.dat";
        private readonly string _dataSchoolTeachers = $"{_dataSourcePath}\\SchoolTeachers.dat";
        private readonly string _dataUniversityTeachers = $"{_dataSourcePath}\\UniversityTeachers.dat";
        private readonly string _dataSchoolTimetable;
        //Списки кабинетов        
        private List<int> _schoolRooms = new List<int>();
        private List<int> _universityRooms = new List<int>();
        //Списки преподавателей
        private List<string> _schoolTeachers = new List<string>();
        private List<string> _universityTeachers = new List<string>();
        //Расписание (отдельно в userSavePath)
        private List<SchoolLesson> _schoolTimetable = new List<SchoolLesson>();
        
        private readonly BinaryFormatter _formatter = new BinaryFormatter();

        public DataSource(string nameFile = "",string dataSourcePath = "c:\\WindowsAppDir\\Source", 
                          string userSavePath = "c:\\WindowsAppDir\\UserSave")
        {
            Directory.CreateDirectory(_userSavePath);
            _dataSchoolTimetable = $"{_userSavePath}\\SchoolTimetable.dat";
            _dataSourcePath = dataSourcePath;
            _userSavePath = userSavePath;
        }
        //Работа с SchoolRooms-----------------------------------------
        public List<int> SchoolRooms
        {
            get => _schoolRooms;
            set => _schoolRooms = value;
        }
        public void AddSchoolRoom(int room)
        {
            _schoolRooms.Add(room);    
        }

        public void RemoveSchoolRoom(int room)
        {
            _schoolRooms.Remove(room);
        }
        /// <summary>
        /// Загрузить данные в файл
        /// </summary>
        public List<int> LoadDataSchoolRooms()
        {
            
            FileStream fs = new FileStream(_dataSchoolRooms, FileMode.OpenOrCreate);
            List<int> schoolRooms = (List<int>)_formatter.Deserialize(fs);
            fs.Close();
            return schoolRooms;
        }
        /// <summary>
        /// Сохранить данные в файл
        /// </summary>
        public void StoreDataSchoolRooms()
        {
            FileStream fs = new FileStream(_dataSchoolRooms, FileMode.OpenOrCreate);
            _formatter.Serialize(fs,_schoolRooms );
            fs.Close();
            
        }
        /// <summary>
        /// Удалить файл с данными
        /// </summary>
        public void DeleteDataSchoolRooms()
        {
            File.Delete(_dataSchoolRooms);
           
        }
        //-------------------------------------------------------------
        
        //Работа с UniversityRooms-------------------------------------
        public List<int> UniversityRooms
        {
            get => _universityRooms;
            set => _universityRooms = value;
        }
        public void AddUniversityRooms(int room)
        {
            _universityRooms.Add(room);
        }

        public void RemoveUniversityRooms(int room)
        {
            _universityRooms.Remove(room);
        }
        /// <summary>
        /// Загрузить данные в файл
        /// </summary>
        public List<int> LoadDataUniversityRooms()
        {
            
            FileStream fs = new FileStream(_dataUniversityRooms, FileMode.OpenOrCreate);
            List<int> universityRooms = (List<int>)_formatter.Deserialize(fs);
            fs.Close();
            return universityRooms;
        }
        /// <summary>
        /// Сохранить данные в файл
        /// </summary>
        public void StoreDataUniversityRooms()
        {
            FileStream fs = new FileStream(_dataUniversityRooms, FileMode.OpenOrCreate);
            _formatter.Serialize(fs,_schoolRooms );
            fs.Close();
            
        }
        /// <summary>
        /// Удалить файл с данными
        /// </summary>
        public void DeleteDataUniversityRooms()
        {
            File.Delete(_dataUniversityRooms);
           
        }
        //-------------------------------------------------------------
        
        //Работа с SchoolTeachers--------------------------------------
        public List<string> SchoolTeachers
        {
            get => _schoolTeachers;
            set => _schoolTeachers = value;
        }
        public void AddSchoolTeachers(string teacher)
        {
            _schoolTeachers.Add(teacher);
        }

        public void RemoveSchoolTeachers(string teacher)
        {
            _schoolTeachers.Remove(teacher);
        }
        /// <summary>
        /// Загрузить данные в файл
        /// </summary>
        public List<string> LoadDataSchoolTeachers()
        {
            FileStream fs = new FileStream(_dataSchoolTeachers, FileMode.OpenOrCreate);
            List<string> schoolTeachers = (List<string>)_formatter.Deserialize(fs);
            fs.Close();
            return schoolTeachers;
        }
        /// <summary>
        /// Сохранить данные в файл
        /// </summary>
        public void StoreDataSchoolTeachers()
        {
            FileStream fs = new FileStream(_dataSchoolTeachers, FileMode.OpenOrCreate);
            _formatter.Serialize(fs,_schoolRooms );
            fs.Close();
            
        }
        /// <summary>
        /// Удалить файл с данными
        /// </summary>
        public void DeleteDataSchoolTeachers()
        {
            File.Delete(_dataSchoolTeachers);
           
        }
        //-------------------------------------------------------------
        
        //Работа с UniversityTeachers----------------------------------
        public List<string> UniversityTeachers
        {
            get => _universityTeachers;
            set => _universityTeachers = value;
        }
        public void AddUniversityTeachers(string teacher)
        {
            _universityTeachers.Add(teacher);
        }

        public void RemoveUniversityTeachers(string teacher)
        {
            _universityTeachers.Remove(teacher);
        }
        /// <summary>
        /// Загрузить данные в файл
        /// </summary>
        public List<string> LoadDataUniversityTeachers()
        {
            
            FileStream fs = new FileStream(_dataUniversityTeachers, FileMode.OpenOrCreate);
            List<string> universityTeachers = (List<string>)_formatter.Deserialize(fs);
            fs.Close();
            return universityTeachers;
        }
        /// <summary>
        /// Сохранить данные в файл
        /// </summary>
        public void StoreDataUniversityTeachers()
        {
            FileStream fs = new FileStream(_dataUniversityTeachers, FileMode.OpenOrCreate);
            _formatter.Serialize(fs,_schoolRooms );
            fs.Close();
            
        }
        /// <summary>
        /// Удалить файл с данными
        /// </summary>
        public void DeleteDataUniversityTeachers()
        {
            File.Delete(_dataUniversityTeachers);
           
        }
        //-------------------------------------------------------------
        
        //Работа с SchoolTimetable-------------------------------------
        public List<SchoolLesson> SchoolTimetable
        {
            get => _schoolTimetable;
            set => _schoolTimetable = value;
        }
        public void AddSchoolTimetable(SchoolLesson lesson)
        {
            _schoolTimetable.Add(lesson);
        }

        public void RemoveSchoolTimetable(SchoolLesson lesson)
        {
            _schoolTimetable.Remove(lesson);
        }
        /// <summary>
        /// Загрузить данные в файл
        /// </summary>
        public List<SchoolLesson> LoadDataSchoolTimetable()
        {
            
            FileStream fs = new FileStream(_dataSchoolTimetable, FileMode.OpenOrCreate);
            List<SchoolLesson> schoolTimetable = (List<SchoolLesson>)_formatter.Deserialize(fs);
            fs.Close();
            return schoolTimetable;
        }
        /// <summary>
        /// Сохранить данные в файл
        /// </summary>
        public void StoreDataSchoolTimetable()
        {
            FileStream fs = new FileStream(_dataSchoolTimetable, FileMode.OpenOrCreate);
            _formatter.Serialize(fs,_schoolRooms );
            fs.Close();
            
        }
        /// <summary>
        /// Удалить файл с данными
        /// </summary>
        public void DeleteDataSchoolTimetable()
        {
            File.Delete(_dataSchoolTimetable);
           
        }
        //-------------------------------------------------------------
    }
}