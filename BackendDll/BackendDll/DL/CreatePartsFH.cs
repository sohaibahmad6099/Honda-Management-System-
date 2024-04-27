using BackendDll.Interfeaces;
using BackendDll.Utilits;
using FormProject.BL;
using System;
using System.Collections.Generic;
using System.IO;

namespace BackendDll
{
    public class CreatePartsFH : ICreateParts
    {
        List<CreateParts> Parts = new List<CreateParts>();
        public void AddParts(CreateParts parts, Users users)
        {
            string filePath = AddressFH.SignInSignUpFH();

            string Name = parts.GetName();
            string Brand = parts.GetBrand();
            int Quantity = parts.GetQuantity();
            float Price = parts.GetPrice();
            int UserID = users.GetUserID();
            int ID = Random() + Random() + Random() + Random() + Random() + Random() + Random() + Random() + Random() + Random() + Random() + Random() + Random() + Random() + Random() + Random();
            string line = $"{UserID},{ID},{Name},{Brand},{Quantity},{Price}";

            try
            {
                File.AppendAllText(filePath, line + Environment.NewLine);
                Console.WriteLine("Data written to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        public bool DeleteParts(int partID)
        {
            try
            {
                string filePath = AddressFH.SignInSignUpFH();
                List<string> lines = new List<string>(System.IO.File.ReadAllLines(filePath));

                int indexToRemove = -1;
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length >= 4 && int.Parse(parts[1]) == partID) 
                    {
                        indexToRemove = i;
                        break;
                    }
                }
                if (indexToRemove != -1)
                {
                    lines.RemoveAt(indexToRemove);
                    System.IO.File.WriteAllLines(filePath, lines);
                    return true;
                }
                else
                {
                    System.Console.WriteLine($"Part with ID '{partID}' not found.");
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        public List<CreateParts> GetDataOfParts()
        {
            string filePath = AddressFH.SignInSignUpFH();
            List<CreateParts> parts = new List<CreateParts>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] partsData = line.Split(',');

                        if (partsData.Length >= 4)
                        {
                            string name = partsData[0];
                            string brand = partsData[1];

                            if (int.TryParse(partsData[2], out int quantity) &&
                                float.TryParse(partsData[3], out float price))
                            {
                                CreateParts part = new CreateParts(name, brand, quantity, price);
                                parts.Add(part);
                            }
                            else
                            {
                                Console.WriteLine($"Error parsing quantity or price in line: {line}. Skipping...");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line: {line}. Skipping...");
                        }
                    }
                }

                Console.WriteLine("Data read from file and stored in list successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return parts;
        }

        public bool GetPart(string partName, int quantity,Users user)
        {
            try
            {
                string filePath = AddressFH.SignInSignUpFH();

                LoadData();

                for (int i = 0; i < Parts.Count; i++)
                {
                    if (partName == Parts[i].GetName())
                    {
                        int value = Parts[i].GetQuantity();
                        if (value - quantity >= 0)
                        {
                            value -= quantity;
                            Parts[i].SetQuantity(value);
                            SetPartsQuantity(quantity, Parts[i].GetName(), user);
                            return true;
                        }
                    }
                }

                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        public void LoadData()
        {
            string filePath = AddressFH.SignInSignUpFH();
            Parts.Clear();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 4)
                {
                    string name = parts[0];
                    string brand = parts[1];
                    int quantity = int.Parse(parts[2]);
                    float price = float.Parse(parts[3]);
                    Parts.Add(new CreateParts(name, brand, quantity, price));
                }
            }
        }

        public void SetPartsQuantity(int quantity, string name, Users user)
        {
            string filePath = AddressFH.SignInSignUpFH();
            string[] lines = File.ReadAllLines(filePath);
            bool recordUpdated = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length >= 4 && parts[0] == name) 
                {
                    parts[2] = quantity.ToString(); 
                    lines[i] = string.Join(",", parts);
                    recordUpdated = true;
                    break;
                }
            }

            if (recordUpdated)
            {
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                Console.WriteLine($"Part with name '{name}' not found.");
            }

        }

        public bool UpdateDataofParts(int id, CreateParts part, Users users)
        {
            string filePath = AddressFH.SignInSignUpFH();
            string[] lines = File.ReadAllLines(filePath);

            bool recordUpdated = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length >= 6 && int.Parse(parts[1]) == id) 
                {
                    parts[3] = part.GetBrand(); 
                    parts[2] = part.GetName().ToString(); 
                    parts[4] = part.GetQuantity().ToString(); 
                    parts[5] = part.GetPrice().ToString(); 

                    lines[i] = string.Join(",", parts);
                    recordUpdated = true;
                    break;
                }
            }

            if (recordUpdated)
            {
                File.WriteAllLines(filePath, lines);
            }

            return recordUpdated;
        }
        private int Random()
        {
            int num;
            Random random = new Random();
            num = random.Next(0, 300000);
            return num;
        }
    }
}
