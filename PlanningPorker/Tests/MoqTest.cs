using Xunit;
using Moq;

namespace Tests;

public class MoqTest
{

    [Fact]
    public void Moqする()
    {
        var mock = new Mock<IEventStore>();
        mock.Setup(x => x.Store(1)).Returns(10);
        mock.Setup(x => x.NotStore(1)).Returns(10);
        
        var target = new TestTargetClass(mock.Object);
        target.Execute();

        // 1回以上呼ばれたことを保証する
        mock.Verify(x => x.Store(1), Times.AtLeastOnce);

        // SetUp した全てのメソッドが1回以上呼ばれたことを保証する。
        mock.VerifyAll();
    }


}

public interface IEventStore
{
    int Store(int value);
    int NotStore(int value);
}
    
public class TestTargetClass {
    public IEventStore client { get; set;}

    public TestTargetClass(IEventStore client)
    {
        this.client = client;
    }

    public int Execute() {
        this.client.Store(1);
        this.client.Store(1);
        this.client.NotStore(1);
        return 10;
    }
}