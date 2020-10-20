from bs4 import BeautifulSoup
import urllib3

http = urllib3.PoolManager()
r = http.request('GET', 'https://en.wikipedia.org/wiki/Battle_of_Wizna')
soup = BeautifulSoup(r.data, 'lxml')
infobox = soup.find(class_ = "infobox")
ths = infobox.find_all("th")
for th in ths:
    print(th.find_all("td")