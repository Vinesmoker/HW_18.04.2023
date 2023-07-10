using System.Collections.Generic;
using System;

abstract class Storage
{
    protected string name;
    protected string model;
    public Storage(string name, string model)
    {
        this.name = name;
        this.model = model;
    }
    public abstract double GetMemorySize();
    public abstract void CopyData(double dataSize);
    public abstract double GetFreeMemory();
    public abstract void PrintInfo();
}

class Flash : Storage
{
    private double usbSpeed;
    private double memorySize;
    public Flash(string name, string model, double usbSpeed, double memorySize) : base(name, model)
    {
        this.usbSpeed = usbSpeed;
        this.memorySize = memorySize;
    }
    public override double GetMemorySize()
    {
        return memorySize;
    }
    public override void CopyData(double dataSize)
    {
        double time = dataSize / usbSpeed;
        Console.WriteLine("Copying {0} MB to {1} {2} ({3} MB) will take {4} seconds.", dataSize, name, model, memorySize, time);
    }
    public override double GetFreeMemory()
    {
        return memorySize;
    }
    public override void PrintInfo()
    {
        Console.WriteLine("Flash memory {0} {1} with {2} MB and USB {3}", name, model, memorySize, usbSpeed);
    }
}

class DVD : Storage
{
    private double readSpeed;
    private double writeSpeed;
    private double capacity;
    public DVD(string name, string model, double readSpeed, double writeSpeed, double capacity) : base(name, model)
    {
        this.readSpeed = readSpeed;
        this.writeSpeed = writeSpeed;
        this.capacity = capacity;
    }
    public override double GetMemorySize()
    {
        return capacity;
    }
    public override void CopyData(double dataSize)
    {
        double time = dataSize / writeSpeed;
        Console.WriteLine("Copying {0} MB to {1} {2} ({3} MB) will take {4} seconds.", dataSize, name, model, capacity, time);
    }
    public override double GetFreeMemory()
    {
        return capacity;
    }
    public override void PrintInfo()
    {
        Console.WriteLine("DVD {0} {1} with {2} MB, read speed {3}, write speed {4}", name, model, capacity, readSpeed, writeSpeed);
    }
}

class HDD : Storage
{
    private double usbSpeed;
    private int partitions;
    private double partitionSize;
    public HDD(string name, string model, double usbSpeed, int partitions, double partitionSize) : base(name, model)
    {
        this.usbSpeed = usbSpeed;
        this.partitions = partitions;
        this.partitionSize = partitionSize;
    }
    public override double GetMemorySize()
    {
        return partitions * partitionSize;
    }
    public override void CopyData(double dataSize)
    {
        double time = dataSize / usbSpeed;
        Console.WriteLine("Copying {0} MB to {1} {2} ({3} partitions with {4} MB each) will take {5} seconds.", dataSize, name, model, partitions, partitionSize, time);
    }
    public override double GetFreeMemory()
    {
        return partitions * partitionSize;
    }
    public override void PrintInfo()
    {
        Console.WriteLine("HDD {0} {1} with {2} partitions, {3} MB each, and USB {4}", name, model, partitions, partitionSize, usbSpeed);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Storage> devices = new List<Storage>();
        devices.Add(new Flash("Flash1", "Kingston", 100, 8000));
        devices.Add(new DVD("DVD1", "Verbatim", 16, 8, 4700));
        devices.Add(new HDD("HDD1", "Seagate", 60, 3, 16384));

        double totalMemory = 0;
        foreach (Storage device in devices)
        {
            totalMemory += device.GetMemorySize();
        }
        Console.WriteLine("Total memory of all devices: {0} MB", totalMemory);

        double dataSize = 565000;
        foreach (Storage device in devices)
        {
            if (device.GetFreeMemory() >= dataSize)
            {
                device.CopyData(dataSize);
                break;
            }
        }

        double totalTime = 0;
        foreach (Storage device in devices)
        {
            totalTime += dataSize / device.GetMemorySize();
        }
        Console.WriteLine("Total time for copying {0} MB: {1} seconds", dataSize, totalTime);

        double flashCount = Math.Ceiling(dataSize / devices[0].GetMemorySize());
        double dvdCount = Math.Ceiling(dataSize / devices[1].GetMemorySize());
        double hddCount = Math.Ceiling(dataSize / devices[2].GetMemorySize());
        Console.WriteLine("Number of Flash drives needed: {0}", flashCount);
        Console.WriteLine("Number of DVDs needed: {0}", dvdCount);
        Console.WriteLine("Number of HDDs needed: {0}", hddCount);

        foreach (Storage device in devices)
        {
            device.PrintInfo();
        }
    }
}