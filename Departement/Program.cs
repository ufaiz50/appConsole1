using System;
using System.Collections.Generic;

namespace Departement
{
    class Program
    {
        static void Main(string[] args)
        {


            //List Object untuk mendapatkan data array satu username satu password
            List<Employees> employee = new List<Employees>();
            employee.Add(new Employees("0001", "faiz", "faiz", "@gmail.com", "rahasia", "admin"));
            employee.Add(new Employees("0002", "izmi", "izmi", "@gmail.com", "sembunyi", "user"));
  
            Employees userLogin = new Employees();

            //Deklarasi & assigment terhadap variabel yang dibutuhkan
            string username, password;
            int trying = 0;
            bool isLogin = false;
            bool isExit = false;

            Console.WriteLine("Selamat Datang di Aplikasi Silahkan Login terlebih dahulu");
            Console.WriteLine("=========================================================");

            //Looping untuk pengecekan username dengan kondisi isTrue dan percobaan
            //login yang di perbolehkan adalah 3 kali
            while (!isExit)
            {

                while (!isLogin && trying < 3)
                {
                    print("username");
                    username = Console.ReadLine();
                    print("password");
                    password = Console.ReadLine();
                    //pengecekan data dengan method non-void "Boolean" isCheck()
                    if (isCheck(employee, username, password))
                    {
                        isLogin = true;
                        userLogin = getRole(employee, username);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();

                        if (trying < 2)
                        {
                            Console.WriteLine("Username atau kata Katasandi Salah");
                            Console.WriteLine("Coba masuk kembali");
                            Console.WriteLine("------------------");
                            Console.WriteLine();
                        }
                    }

                    trying++;
                }

                if (isLogin)
                {
                    trying = 0;

                    while (isLogin)
                    {
                        Console.WriteLine("===========================");
                        Console.WriteLine("Selamat Datang di Dashboard");
                        Console.WriteLine("===========================");
                        Console.WriteLine("1. Tampilkan Data");
                        if (userLogin.Role.Equals("admin")) {
                            Console.WriteLine("2. Tambahkan Data");
                            Console.WriteLine("3. Hapus Data");
                        }
                        Console.WriteLine("0. Keluar Aplikasi");
                        Console.WriteLine();



                        int choose;
                        choose = getOption();
                        switch (choose)
                        {
                            case 1:
                                Console.Clear();
                                showData(employee);
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.Clear();
                                addData(employee);
                                break;
                            case 3:
                                Console.Clear();
                                deleteData(employee);
                                break;
                            case 0:
                                Console.Clear();
                                isExit = true;
                                break;
                            default:
                                Console.WriteLine("Pilihan tersedia");
                                break;
                        }

                    jump:
                        if (choose != 0)
                        {


                            Console.Write("apakah anda ingin kembali ke menu (y/n) : ");

                            try
                            {
                                char answer = Convert.ToChar(Console.ReadLine());
                                if (answer == 'y')
                                {
                                    isLogin = true;
                                    Console.Clear();
                                }
                                else if (answer == 'n')
                                {
                                    isLogin = false;
                                }
                                else
                                {
                                    Console.WriteLine("hanya boleh input (y/n)");
                                    goto jump;
                                }
                                

                            }
                            catch (FormatException)
                            {
                                
                                Console.WriteLine("hanya boleh input (y/n)");
                                goto jump;
                            }
                        }
                    }

                }
                //jika kondisi login tidak benar dan percobaan sudah sampai 3x maka user tidak bisa
                //melakukan login kembali
                else
                {
                    Console.WriteLine("===> Maaf anda sudah melampui batas percobaan login <===");
                    Console.WriteLine("===>       Anda Telah keluar dari aplikasi          <===");
                    isExit = true;
                }
                Console.WriteLine("===> anda telah berhasil Logput <===");
                isExit = false;

            }
    
            //jika kondisi login benar maka data dashboard akan ditampilkan
            //Console.WriteLine("===== Anda telah berhasil Keluar =====");
            Console.ReadLine();

        }

        //menggunakan lambda/anonymous method untuk melakukan perintah cetak
        //di perintah readline yang ada
        static void print(string param) => Console.Write("Masukkan " + param + " = ");

        //method isCheck untuk melakukan validasi akun berdasarkan dengan data yang ada
        //1 username, 1 password dengan tambahan operator "&&" 
        static bool isCheck(List<Employees> users, string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    return true;
                }
            }

            return false;
        }

        //mendapatkan nilai option
        static int getOption()
        {
            print("pilihan anda");
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }catch (FormatException)
            {
                Console.WriteLine("Hanya boleh memasukkan angka");
                return getOption();
            }
        }

        //Menampilkan data list object yang ada dimana object bernama person
        static void showData(List<Employees> users)
        {
            
            Console.WriteLine("===== Data yang sudah ada =====");
            Console.WriteLine("| NO |\tNIK\t|\tName\t|\tEmail\t\t|\tUsername\t|");
            int no = 1;
            foreach (var user in users)
            {
                Console.WriteLine($"| {no}. |\t{user.Nik}\t|\t{user.Name}\t|\t{user.Email}\t|\t{user.Username}\t\t|");
                no++;
            }
            
        }

        //Menambahkan data
        static void addData(List<Employees> users) {
            showData(users);
            Console.WriteLine();
            int nik = Convert.ToInt32(users[users.Count - 1].Nik);
            nik++;
            print("Masukkan Nama");
            string name = Console.ReadLine();
            print("Masukkan Username");
            string username = Console.ReadLine();
            print("Masukkan Email");
            string email = Console.ReadLine();
            print("masukkan Password");
            string password = Console.ReadLine();
            print("masukkan Role(admin/user");
            string role = Console.ReadLine();
            users.Add(new Employees($"000{nik}", name, username, email, password, role));
            Console.WriteLine("====> Data Berhasil di Tambah <====");
            Console.WriteLine();
        }

        //menghapus data
        static void deleteData(List<Employees> users) {
            showData(users);
            Console.WriteLine();
            Console.WriteLine("====> Pilih data yang ingin dihapus <====");
            try
            {
                int option = getOption();
                users.RemoveAt(option - 1);
                Console.WriteLine("====> Data berhasil di Hapus <====");
                Console.WriteLine();

            } catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Maaf tidak ada nomer tersebut");
            }

        }

        static Employees getRole(List<Employees> users, string username)
        {

            foreach (var user in users)
            {
                if (user.Username.Equals(username))
                {
                    return user;
                }
            }
            return new Employees();
        }
    }

    //Membuat Object Person

}
