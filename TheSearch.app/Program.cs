using TheSearch.app;

var criminals = new List<Criminal>
{
    new()
    {
        FirstName = "John",
        Lastname = "Smith",
        Height = 160,
        Weight = 50,
        Nationality = "Indian"
    },
    new()
    {
        FirstName = "Jane",
        Lastname = "Johnson",
        Height = 168,
        Weight = 56,
        Nationality = "Canadian"
    },
    new()
    {
        FirstName = "Michael",
        Lastname = "Brown",
        Height = 183,
        Weight = 60,
        Nationality = "Australian"
    },
    new()
    {
        FirstName = "William",
        Lastname = "Wilson",
        Height = 190,
        Weight = 90,
        Nationality = "Scottish"
    },
    new()
    {
        FirstName = "Sophia",
        Lastname = "Clark",
        Height = 160,
        Weight = 51,
        Nationality = "South African"
    }
};



/*Задача:
У нас есть список всех преступников.

Вашей программой будут пользоваться детективы.
У детектива запрашиваются данные (рост, вес, национальность)
  и детективу выводятся все преступники которые подходят под эти параметры,
    но уже заключенные под стражу выводиться не должны.*/