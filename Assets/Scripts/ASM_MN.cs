using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Threading;
using System;

public class ASM_MN : Singleton<ASM_MN>
{
    public List<Region> listRegion = new List<Region>();
    public List<Players> listPlayer = new List<Players>();

    private void Start()
    {
        createRegion();
    }

    public void createRegion()
    {
        listRegion.Add(new Region(0, "VN"));
        listRegion.Add(new Region(1, "VN1"));
        listRegion.Add(new Region(2, "VN2"));
        listRegion.Add(new Region(3, "JS"));
        listRegion.Add(new Region(4, "VS"));
    }

    private string calculate_rank()
    {
        /* Viết code trong hàm calculate_rank để tính rank cho người chơi như sau:
        score < 100: Hạng đồng
        100 <= score < 500: Bạc
        500 <= score < 1000: Vàng
        score >= 1000: Kim cương */
        Debug.Log("YC2: ");
        foreach (Players player in listPlayer)
        {
            if (player.Score < 100)
                Debug.Log("ID: " + player.Id + " |Player Name: " + player.Name + " | Score: " + player.Score + " | Region: " + player.PlayerRegion.Name + " | Rank: Hạng đồng");
            else if (player.Score < 500)
                Debug.Log("ID: " + player.Id + " |Player Name: " + player.Name + " | Score: " + player.Score + " | Region: " + player.PlayerRegion.Name + " | Rank: Hạng bạc");
            else if (player.Score < 1000)
                Debug.Log("ID: " + player.Id + " |Player Name: " + player.Name + " | Score: " + player.Score + " | Region: " + player.PlayerRegion.Name + " | Rank: Hạng vàng");
            else
                Debug.Log("ID: " + player.Id + " |Player Name: " + player.Name + " | Score: " + player.Score + " | Region: " + player.PlayerRegion.Name + " | Rank: Hạng kim cương");
        }

        return null;
    }

    public void YC1()
    {
        string name = ScoreKeeper.Instance.GetUserName();
        int id = ScoreKeeper.Instance.GetID();
        int idRegion = ScoreKeeper.Instance.GetIDregion();
        int score = ScoreKeeper.Instance.GetScore();

        string regionName = "";

        // Lấy theo Id
        if (idRegion == 0)
        {
            regionName = "VN";
        }
        else if (idRegion == 1)
        {
            regionName = "VN1";
        }
        else if (idRegion == 2)
        {
            regionName = "VN2";
        }
        else if (idRegion == 3)
        {
            regionName = "JS";
        }
        else if (idRegion == 4) 
        {
            regionName = "VS";
        }
        else
        {
            Debug.Log("Not found....................");
        }

        // Thhông tin người chơi ban đầu
        Players player1 = new Players(id, "Khánh", 1100, new Region(2,"VN2"));
        listPlayer.Add(player1);
        Players player2 = new Players(id, "Huy", 85, new Region(3, "JS"));
        listPlayer.Add(player2);
        Players player3 = new Players(id, "Nam", 700, new Region(4, "VS"));
        listPlayer.Add(player3);
        Players player4 = new Players(id, "Đạt", 225, new Region(1, "VN1"));
        listPlayer.Add(player4);
        Players player5 = new Players(id, "Hiền", 645, new Region(1, "VN1"));
        listPlayer.Add(player5);
        Players player6 = new Players(id, "Ngọc", 450, new Region(1, "VN1"));
        listPlayer.Add(player6);

        // Thêm thông tin người chơi mới khi nhập từ text 
        Region playerRegionA = new Region(idRegion, regionName);
        Players playerA = new Players (id, name, score, playerRegionA);

        listPlayer.Add(playerA);


    }
    public void YC2()
    {
        // Duyệt và in thông tin các Players 
        calculate_rank();
    }
    public void YC3()
    {
        // Viết code trong hàm YC3 xuất thông tin các Player có score bé hơn score hiện tại của người chơi.
        Debug.Log("YC3:");
        var yc3 = listPlayer.OrderBy(i => i.Score); // Sắp xếp listPlayer theo thứ tự tăng dần 
        foreach (Players player in yc3)
        {
            Debug.Log("ID: " + player.Id + " | Player Name: " + player.Name + " | Score: " + player.Score + " | Region: " + player.PlayerRegion.Name);
            break; //Hiển thị người chơi đầu tiên rồi dừng vòng lặp 
        }
    }
    public void YC4()
    {
        Debug.Log("YC4:");
        // Viết code trong hàm YC4, sử dụng Linq để tìm Player theo Id của người chơi hiện tại,
        // in ra thông tin sau khi kết thúc màn chơi.
        var yc4 = listPlayer.LastOrDefault();
        Debug.Log("ID: " + yc4.Id + " | Player Name: " + yc4.Name + " | Score: " + yc4.Score + " | Region: " + yc4.PlayerRegion.Name);
    }
    public void YC5()
    {
        // Viết code trong hàm YC5 xuất thông tin các Player trong listPlayer theo thứ tự score giảm dần.
        Debug.Log("YC5:");
        // OrderByDescending để sắp xếp theo thứ tự giảm dần
        var yc5 = listPlayer.OrderByDescending(i => i.Score); 
        foreach (var item in yc5)
        {
            Debug.Log("Player Name: " + item.Name + " | Score: " + item.Score);
        }
    }
    public void YC6()
    {
        // Viết code trong hàm YC6 xuất thông tin 5 player có score thấp nhất theo thứ tự tăng dần.
        Debug.Log("YC6:");
        // OrderBy để sắp xếp theo thứ tự tăng dần và Take để lấy giá trị đầu tiên
        var yc6 = listPlayer.OrderBy(i => i.Score).Take(5);
        foreach(var item in yc6)
        {
            Debug.Log("Player Name: " + item.Name + " | Score: " + item.Score);
        }
    }
    public void YC7()
    {
        // sinh viên viết tiếp code ở đây

    }
    void CalculateAndSaveAverageScoreByRegion()
    {
        // sinh viên viết tiếp code ở đây
    }

}

[SerializeField]
public class Region
{
    public int ID;
    public string Name;
    public Region(int ID, string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }
}

[SerializeField]
public class Players
{
    // sinh viên viết tiếp code ở đây
    public int Id {  get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public Region PlayerRegion { get; set; }
    ScoreKeeper sc;

    public Players (int id, string name, int score, Region region)
    {
        Id = region.ID;
        Name = name;
        Score = score;
        PlayerRegion = region;
    }
}