#include <iostream>

using namespace std;

struct TestClass
{
    string name;

    TestClass()
    {
        this->name = "";
        printf("Empty Constructor\n");
    }
    TestClass(const std::string& name)
    {
        this->name = name;
        printf("Constructor. name : %s\n", name.c_str());
    }
    ~TestClass()
    {
        printf("Destructor. name : %s\n", name.c_str());
    }
    TestClass(const TestClass& rhs)
    {
        this->name = rhs.name;
        printf("CopyConstructor. name : %s\n", name.c_str());
    }
    TestClass& operator=(const TestClass& rhs)
    {
        this->name = rhs.name;
        printf("Copy Operator. name : %s\n", name.c_str());
        return *this;
    }
};

//RVO
TestClass GetTestClassByReturn(const std::string& name)
{
    return TestClass(name);
}

//NRVO
TestClass GetTestClassByVariable(const std::string& name)
{
    TestClass value(name);
    return value;
}

//Assign
void TestAssign(const std::string& name)
{
    TestClass value(name);
    TestClass value2 = value;
}

//Hand optimized?
void GetTestClassByRef(const std::string& name, TestClass& output)
{
    output = TestClass(name);
}

struct Test2Class
{
    char* ptr;
    int integer;
};

Test2Class BugTest()
{
    Test2Class value = { 0, };
    printf("%p %d\n", value.ptr, value.integer);

    return value;
}

int main()
{
    //TestAssign("Lyn");
    //auto a = GetTestClassByReturn("Lyn");
    //auto b = GetTestClassByVariable("Lyn");
    //TestClass t; GetTestClassByRef("Lyn", t);
    auto c = BugTest();

    printf("Program End\n");
}
