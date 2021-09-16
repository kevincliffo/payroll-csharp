-- phpMyAdmin SQL Dump
-- version 4.3.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 20, 2016 at 03:06 PM
-- Server version: 5.6.24
-- PHP Version: 5.5.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `payroll`
--

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

CREATE TABLE IF NOT EXISTS `attendance` (
  `AttendanceId` int(11) NOT NULL,
  `EmployeeId` int(11) NOT NULL,
  `AttendanceType` int(11) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `Hours` double(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `attendance`
--

INSERT INTO `attendance` (`AttendanceId`, `EmployeeId`, `AttendanceType`, `Date`, `Hours`) VALUES
(1, 1, 0, '13.04.2016', 1.00),
(2, 2, 1, '05.04.2016', 4.00),
(3, 1, 0, '15.04.2016', 4.00),
(4, 1, 1, '16.04.2016', 0.30);

-- --------------------------------------------------------

--
-- Table structure for table `deductions`
--

CREATE TABLE IF NOT EXISTS `deductions` (
  `DeductionId` int(11) NOT NULL,
  `NHIF` double(10,2) NOT NULL,
  `NSSF` double(10,2) NOT NULL,
  `Pension` double(10,2) NOT NULL,
  `PersonalRelief` double(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `deductions`
--

INSERT INTO `deductions` (`DeductionId`, `NHIF`, `NSSF`, `Pension`, `PersonalRelief`) VALUES
(1, 1700.00, 1080.00, 4000.00, 1020.00);

-- --------------------------------------------------------

--
-- Table structure for table `defaults`
--

CREATE TABLE IF NOT EXISTS `defaults` (
  `DefaultId` int(11) NOT NULL,
  `DefaultName` varchar(200) NOT NULL,
  `DefaultDescription` varchar(200) NOT NULL,
  `Value` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `defaults`
--

INSERT INTO `defaults` (`DefaultId`, `DefaultName`, `DefaultDescription`, `Value`) VALUES
(1, 'HoursPerDay', 'Hours Per Day', '9'),
(2, 'WorkDaysPerMonth', 'Work Days Per Month', '21'),
(3, 'OverTimeRate', 'Over Time Rate', '1.1'),
(4, 'NHIF', 'NHIF', '1700'),
(5, 'NSSF', 'NSSF', '1080'),
(6, 'PersonalRelief', 'Personal Relief', '1162'),
(7, 'Pension', 'Pension', '4000');

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE IF NOT EXISTS `employees` (
  `EmployeeId` int(11) NOT NULL,
  `FirstName` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `OtherName` varchar(100) NOT NULL,
  `RegNumber` varchar(100) NOT NULL,
  `MobileNo` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `EmploymentDate` varchar(100) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `Residence` varchar(100) NOT NULL,
  `Role` varchar(100) NOT NULL,
  `Salary` double(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`EmployeeId`, `FirstName`, `LastName`, `OtherName`, `RegNumber`, `MobileNo`, `Email`, `EmploymentDate`, `Address`, `Residence`, `Role`, `Salary`) VALUES
(1, 'Kevin', 'Owino', 'Ochieng', 'EMP-0001', '0711451145', 'kevinochieng@gmail.com', '04.01.2010', '83-80122 Kengeleni', 'Kongowea', 'Director', 89700.00),
(2, 'Anne', 'Naomi', 'Chege', 'EMP-0002', '0745123411', 'annechege@gmail.com', '12.04.2012', '45 Mombasa', 'Mtwapa', 'Manager', 65000.00),
(3, 'Alfayo', 'Njoroge', 'John', 'EMP-0003', '0725615545', 'alfayonjoroge@gmail.com', '02.08.2010', '45 Mombasa', 'Likoni', 'Manager', 78000.00),
(4, 'Japeth', 'Mbugua', 'Waweru', 'EMP-0004', '0745121212', 'japethmbugua@gmail.com', '01.12.2015', '57 Mtwapa', 'Mtwapa', 'Normal', 67500.00);

-- --------------------------------------------------------

--
-- Table structure for table `payrollcalculation`
--

CREATE TABLE IF NOT EXISTS `payrollcalculation` (
  `PayRollId` int(11) NOT NULL,
  `EmployeeId` int(11) NOT NULL,
  `FirstName` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `OtherName` varchar(100) NOT NULL,
  `Date` varchar(100) NOT NULL,
  `Role` varchar(100) NOT NULL,
  `Salary` double(10,2) NOT NULL,
  `GrossSalary` double(10,2) NOT NULL,
  `NHIF` double(10,2) NOT NULL,
  `NSSF` double(10,2) NOT NULL,
  `Pension` double(10,2) NOT NULL,
  `Relief` double(10,2) NOT NULL,
  `PAYE` double(10,2) NOT NULL,
  `NetSalary` double(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `payrollcalculation`
--

INSERT INTO `payrollcalculation` (`PayRollId`, `EmployeeId`, `FirstName`, `LastName`, `OtherName`, `Date`, `Role`, `Salary`, `GrossSalary`, `NHIF`, `NSSF`, `Pension`, `Relief`, `PAYE`, `NetSalary`) VALUES
(0, 1, 'Kevin', 'Owino', 'Ochieng', '20.04.2016', 'Director', 89700.00, 92153.70, 1700.00, 1080.00, 4000.00, 1162.00, 22740.51, 63795.19),
(1, 2, 'Anne', 'Naomi', 'Chege', '20.04.2016', 'Manager', 65000.00, 63624.34, 1700.00, 1080.00, 4000.00, 1162.00, 14181.70, 43824.64),
(2, 3, 'Alfayo', 'Njoroge', 'John', '20.04.2016', 'Manager', 78000.00, 78000.00, 1700.00, 1080.00, 4000.00, 1162.00, 18494.40, 53887.60),
(3, 4, 'Japeth', 'Mbugua', 'Waweru', '20.04.2016', 'Normal', 67500.00, 67500.00, 1700.00, 1080.00, 4000.00, 1162.00, 15344.40, 46537.60);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `UserId` int(11) NOT NULL,
  `UserName` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `UserType` int(11) NOT NULL,
  `FirstName` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `OtherName` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `MobileNo` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserId`, `UserName`, `Password`, `UserType`, `FirstName`, `LastName`, `OtherName`, `Email`, `MobileNo`) VALUES
(1, 'admin', 'CxkneNeT9Ho77Nex7ZT+Cw==', 0, 'Kevin', 'Owino', 'Ochieng', 'kevinochieng@gmail.com', '0724156715');

-- --------------------------------------------------------

--
-- Table structure for table `xdeductions`
--

CREATE TABLE IF NOT EXISTS `xdeductions` (
  `DeductionId` double(10,2) NOT NULL,
  `NHIF` double(10,2) NOT NULL,
  `NSSF` double(10,2) NOT NULL,
  `Pension` double NOT NULL,
  `PersonalRelief` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `xdeductions`
--

INSERT INTO `xdeductions` (`DeductionId`, `NHIF`, `NSSF`, `Pension`, `PersonalRelief`) VALUES
(1.00, 1700.00, 1080.00, 4000, '1020');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `attendance`
--
ALTER TABLE `attendance`
  ADD PRIMARY KEY (`AttendanceId`);

--
-- Indexes for table `deductions`
--
ALTER TABLE `deductions`
  ADD PRIMARY KEY (`DeductionId`);

--
-- Indexes for table `defaults`
--
ALTER TABLE `defaults`
  ADD PRIMARY KEY (`DefaultId`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`EmployeeId`);

--
-- Indexes for table `payrollcalculation`
--
ALTER TABLE `payrollcalculation`
  ADD PRIMARY KEY (`PayRollId`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserId`);

--
-- Indexes for table `xdeductions`
--
ALTER TABLE `xdeductions`
  ADD PRIMARY KEY (`DeductionId`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
