#include <string>

using namespace std;

#ifndef FILEINTERFACE_H
#define FILEINTERFACE_H

class FileInterface
{
private:
    string remoteApi;
    string lastUpdate;
    string title;
    string text;
    string file;
    bool modified;
    void FileOperation(bool);
public:
    FileInterface();
    FileInterface(string);
    void newFile();
    void loadFile(string);
    void saveFile(string = NULL);
    bool isNewFile();
    void setRemoteApi(string);
    string getRemoteApi();
    void setLastUpdate(string);
    string getLastUpdate();
    void setTitle(string);
    string getTitle();
    void setText(string);
    string getText();
    string getFile();
    void dump();
};

#endif // FILEINTERFACE_H
