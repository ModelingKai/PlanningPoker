using Domain;

namespace Tests;


public class 参加者Test
{
    [Fact]
    public void 参加者はポイントを決めることができる() {
        var sankasha = new 参加者();

        // game.参加(sankasha);
        // game.ポイントを出す(Point(1), sankashaId);

        var ポイント決まったイベント = sankasha.ポイントを決める(new ポイント(1));
        // var point = sankasha.ポイントをとる();
        

        // assertion
        Assert.Equal(ポイント決まったイベント.value, 1);



        // ゲーム.Subscribe(ポイント決まったイベントたち);
    }
}

// イメージ・・・
// class ゲーム
// {
//     void Handleポイント決まった() 
//     {
//         xxx...
//     }
// }
