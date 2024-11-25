<?php

final class dbHandler
{

    private $dataSource = "mysql:dbname=divelocations;host=localhost";
    private $username = "root";
    private $password = "";

    public function selectDrivers()
    {
        try {
            $pdo = new PDO($this->dataSource, $this->username, $this->password);
            $statement = $pdo->prepare("Select * from driver;");
            $statement->execute();
            return $result = $statement->fetchAll(PDO::FETCH_ASSOC);
        } catch (PDOException $exception) {
            return false;
        }
    }

    public function deleteDriver($id)
    {
        try {
            $pdo = new PDO($this->dataSource, $this->username, $this->password);
            $statement = $pdo->prepare("DELETE FROM driver WHERE id = :id");
            $statement->bindParam(':id', $id);
            return $statement->execute();
        } catch (PDOException $exception) {
            return false;
        }
    }

    // Haal een coureur op op basis van het ID
    public function getDriverById($id)
    {
        try {
            $pdo = new PDO($this->dataSource, $this->username, $this->password);
            $statement = $pdo->prepare("SELECT * FROM driver WHERE id = :id");
            $statement->bindParam(':id', $id);
            $statement->execute();
            return $statement->fetch(PDO::FETCH_ASSOC);
        } catch (PDOException $exception) {
            return false;
        }
    }

    // Update een coureur
    public function updateDriver($id, $name, $points, $position)
    {
        try {
            $pdo = new PDO($this->dataSource, $this->username, $this->password);
            $statement = $pdo->prepare(
                "UPDATE driver SET name = :name, points = :points, position = :position WHERE id = :id"
            );
            $statement->bindParam(':name', $name);
            $statement->bindParam(':points', $points);
            $statement->bindParam(':position', $position);
            $statement->bindParam(':id', $id);
            return $statement->execute();
        } catch (PDOException $exception) {
            return false;
        }
    }

    // create een coureur
    public function createDriver($name, $points, $position)
    {
        try {
            $pdo = new PDO($this->dataSource, $this->username, $this->password);
            $statement = $pdo->prepare(
                "INSERT INTO driver (id, name, points, position) VALUES (NULL, :name, :points, :position);"
            );
            $statement->bindParam(':name', $name);
            $statement->bindParam(':points', $points);
            $statement->bindParam(':position', $position);
            return $statement->execute();
        } catch (PDOException $exception) {
            return false;
        }
    }
}

