.class public final Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;
.super Ljava/lang/Object;
.source "FlareBearActivity.kt"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/fireeye/flarebear/FlareBearActivity;->dance(Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = null
.end annotation

.annotation runtime Lkotlin/Metadata;
    bv = {
        0x1,
        0x0,
        0x3
    }
    d1 = {
        "\u0000\u0011\n\u0000\n\u0002\u0018\u0002\n\u0000\n\u0002\u0010\u0002\n\u0000*\u0001\u0000\u0008\n\u0018\u00002\u00020\u0001J\u0008\u0010\u0002\u001a\u00020\u0003H\u0016\u00a8\u0006\u0004"
    }
    d2 = {
        "com/fireeye/flarebear/FlareBearActivity$dance$r$1",
        "Ljava/lang/Runnable;",
        "run",
        "",
        "app_release"
    }
    k = 0x1
    mv = {
        0x1,
        0x1,
        0xf
    }
.end annotation


# instance fields
.field final synthetic $drawable:Landroid/graphics/drawable/Drawable;

.field final synthetic $drawable2:Landroid/graphics/drawable/Drawable;

.field final synthetic $handlerDancing:Landroid/os/Handler;

.field final synthetic this$0:Lcom/fireeye/flarebear/FlareBearActivity;


# direct methods
.method constructor <init>(Lcom/fireeye/flarebear/FlareBearActivity;Landroid/os/Handler;Landroid/graphics/drawable/Drawable;Landroid/graphics/drawable/Drawable;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/os/Handler;",
            "Landroid/graphics/drawable/Drawable;",
            "Landroid/graphics/drawable/Drawable;",
            ")V"
        }
    .end annotation

    .line 350
    iput-object p1, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    iput-object p2, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->$handlerDancing:Landroid/os/Handler;

    iput-object p3, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->$drawable2:Landroid/graphics/drawable/Drawable;

    iput-object p4, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->$drawable:Landroid/graphics/drawable/Drawable;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 5

    .line 352
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->$handlerDancing:Landroid/os/Handler;

    move-object v1, p0

    check-cast v1, Ljava/lang/Runnable;

    const-wide/16 v2, 0x1f4

    invoke-virtual {v0, v1, v2, v3}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 353
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    sget v1, Lcom/fireeye/flarebear/R$id;->flareBearImageView:I

    invoke-virtual {v0, v1}, Lcom/fireeye/flarebear/FlareBearActivity;->_$_findCachedViewById(I)Landroid/view/View;

    move-result-object v0

    check-cast v0, Landroid/widget/ImageView;

    const-string v1, "flareBearImageView"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0}, Landroid/widget/ImageView;->getTag()Ljava/lang/Object;

    move-result-object v0

    const-string v2, "ecstatic"

    invoke-static {v0, v2}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    const-string v3, "ecstatic2"

    if-eqz v0, :cond_0

    .line 354
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    sget v1, Lcom/fireeye/flarebear/R$id;->flareBearImageView:I

    invoke-virtual {v0, v1}, Lcom/fireeye/flarebear/FlareBearActivity;->_$_findCachedViewById(I)Landroid/view/View;

    move-result-object v0

    check-cast v0, Landroid/widget/ImageView;

    iget-object v1, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->$drawable2:Landroid/graphics/drawable/Drawable;

    invoke-virtual {v0, v1}, Landroid/widget/ImageView;->setImageDrawable(Landroid/graphics/drawable/Drawable;)V

    .line 355
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    sget v1, Lcom/fireeye/flarebear/R$id;->flareBearImageView:I

    invoke-virtual {v0, v1}, Lcom/fireeye/flarebear/FlareBearActivity;->_$_findCachedViewById(I)Landroid/view/View;

    move-result-object v0

    check-cast v0, Landroid/widget/ImageView;

    invoke-virtual {v0, v3}, Landroid/widget/ImageView;->setTag(Ljava/lang/Object;)V

    goto :goto_0

    .line 356
    :cond_0
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    sget v4, Lcom/fireeye/flarebear/R$id;->flareBearImageView:I

    invoke-virtual {v0, v4}, Lcom/fireeye/flarebear/FlareBearActivity;->_$_findCachedViewById(I)Landroid/view/View;

    move-result-object v0

    check-cast v0, Landroid/widget/ImageView;

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {v0}, Landroid/widget/ImageView;->getTag()Ljava/lang/Object;

    move-result-object v0

    invoke-static {v0, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 357
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    sget v1, Lcom/fireeye/flarebear/R$id;->flareBearImageView:I

    invoke-virtual {v0, v1}, Lcom/fireeye/flarebear/FlareBearActivity;->_$_findCachedViewById(I)Landroid/view/View;

    move-result-object v0

    check-cast v0, Landroid/widget/ImageView;

    iget-object v1, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->$drawable:Landroid/graphics/drawable/Drawable;

    invoke-virtual {v0, v1}, Landroid/widget/ImageView;->setImageDrawable(Landroid/graphics/drawable/Drawable;)V

    .line 358
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->this$0:Lcom/fireeye/flarebear/FlareBearActivity;

    sget v1, Lcom/fireeye/flarebear/R$id;->flareBearImageView:I

    invoke-virtual {v0, v1}, Lcom/fireeye/flarebear/FlareBearActivity;->_$_findCachedViewById(I)Landroid/view/View;

    move-result-object v0

    check-cast v0, Landroid/widget/ImageView;

    invoke-virtual {v0, v2}, Landroid/widget/ImageView;->setTag(Ljava/lang/Object;)V

    goto :goto_0

    .line 361
    :cond_1
    iget-object v0, p0, Lcom/fireeye/flarebear/FlareBearActivity$dance$r$1;->$handlerDancing:Landroid/os/Handler;

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Landroid/os/Handler;->removeCallbacksAndMessages(Ljava/lang/Object;)V

    :goto_0
    return-void
.end method
