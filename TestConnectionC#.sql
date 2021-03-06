CREATE DATABASE COMPANY_MANAGEMENT
GO

USE COMPANY_MANAGEMENT
GO

CREATE TABLE NHANVIEN (
	MANV		INT,
	TENNV		NVARCHAR(20),
	NGAYSINH	DATE,
	GIOITINH	NVARCHAR(20),
	CHUCVU		NVARCHAR(20),
	LUONG		INT

	PRIMARY KEY(MANV)
);

INSERT INTO NHANVIEN(MANV, TENNV, NGAYSINH, GIOITINH, CHUCVU, LUONG)
VALUES (1, 'TRUNG', '1992-12-02', 'NAM', 'CEO', 30000000)

INSERT INTO NHANVIEN(MANV, TENNV, NGAYSINH, GIOITINH, CHUCVU, LUONG)
VALUES (2, 'LINH', '1998-11-06', N'NỮ', 'ACCOUNTANT', 15000000)

INSERT INTO NHANVIEN(MANV, TENNV, NGAYSINH, GIOITINH, CHUCVU, LUONG)
VALUES (3, 'LONG', '2000-02-15', 'NAM', 'PRODUCT MANAGER', 50000000)

CREATE OR ALTER PROCEDURE INSERT_NHANVIEN (
		@MANV			INTEGER,
                @TENNV		NVARCHAR(20),
                @NGAYSINH		DATE,
                @GIOITINH		NVARCHAR(20),
                @CHUCVU		NVARCHAR(20),
		@LUONG		INT)
AS
BEGIN
	SET @MANV = (SELECT MAX(DBO.NHANVIEN.MANV) FROM DBO.NHANVIEN)
	SET @MANV = @MANV + 1;
	INSERT INTO NHANVIEN(MANV, TENNV, NGAYSINH, GIOITINH, CHUCVU, LUONG)
	VALUES (@MANV, @TENNV, @NGAYSINH, @GIOITINH, @CHUCVU, @LUONG)
END

EXEC INSERT_NHANVIEN NULL, 'NUONG', '2000-01-01', N'NỮ', 'SALE', 15000000


